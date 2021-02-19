using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using TMPro;
using Firebase.Database;
using UnityEngine.SceneManagement;
public class AuthManager1 : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public static DependencyStatus dependencyStatus;
    public static FirebaseAuth auth;
    public static FirebaseUser User;
    public static DatabaseReference DBReference;

    //Login variables
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    public TMP_Text warningLoginText;
    public TMP_Text confirmLoginText;


    //Register variables
    [Header("Register")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField passwordRegisterVerifyField;
    public TMP_Text warningRegisterText;

    [Header("Data")]
    public static string username; // come sotto, anzi volendo si potrebbe anche evitare di mostrarlo, e' inutile ma figo...
    public static int livello; //il livello viene inserito pubblicamente tramite l 'inputfield (er textbox), chiaramente a noi non importa questa cosa, è solo per vedere se funzia
    public TMP_Text testoWarning; // questo dice le cose quando salvi



    private static int livelloMenu;
    public string nomeScena;
    void Awake()
    {
        
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBReference = FirebaseDatabase.DefaultInstance.RootReference;
    }


    public void LoginButton() //qua inizia il login
    {
        //chiama la coroutine con email e pass
        StartCoroutine(Login(emailLoginField.text, passwordLoginField.text));
    }
    //Function for the register button
    public void RegisterButton()
    {
        //Call the register coroutine passing the email, password, and username
        StartCoroutine(Register(emailRegisterField.text, passwordRegisterField.text, usernameRegisterField.text));
    }


    //funzione presa in giro ma che funziona
    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password 
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            //If there are errors handle them
            Debug.LogWarning(message: $"Failed to register task with {LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "Login fallito!";
            switch (errorCode)
            {
                case AuthError.MissingEmail:
                    message = "Compila il campo mail";
                    break;
                case AuthError.MissingPassword:
                    message = "compila il campo password";
                    break;
                case AuthError.WrongPassword:
                    message = "Password errata!";
                    break;
                case AuthError.InvalidEmail:
                    message = "L'email inserita non risulta valida";
                    break;
                case AuthError.UserNotFound:
                    message = "Questo Account non esiste, registrati!";
                    break;
            }
            warningLoginText.text = message;
        }
        else
        {
            //User is now logged in
            //Now get the result
            User = LoginTask.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})", User.DisplayName, User.Email);
            warningLoginText.text = "";
            confirmLoginText.text = "Accesso Riuscito";

            StartCoroutine(UpdateErLivello(1));
            SceneManager.LoadScene("cartellob");
            StartCoroutine(LoadUserData()); // una volta che accedo carico i dati dell'utente
            
            yield return new WaitForSeconds(2);

            username = User.DisplayName;
            LoadUserData();
            
            //UIManager.instance.Erlivello(); 
            //SceneManager.LoadScene("Menu");
            confirmLoginText.text = "";
            Pulisci();
            
        }
    }

    public void Pulisci()
    {
        // campi parte login

        emailLoginField.text = "";
        passwordLoginField.text = "";

        //campi nella parte registra

        usernameRegisterField.text = "";
        emailRegisterField.text = "";
        passwordRegisterField.text = "";
        passwordRegisterVerifyField.text = "";
    }

    public void SignOut()
    {
        auth.SignOut();
        UIManager.instance.LoginScreen();
        Pulisci();
    }

    public void SaveDataButton()
    {
        StartCoroutine(UpdateUsernameAuth(username)); //update dell'username, anche se non credo si possa cambiare ma vabbe
        StartCoroutine(UpdateUsernameDatabase(username));


      //  StartCoroutine(UpdateErLivello(int.Parse(livello.text))); //update der livello

        testoWarning.text = "Hai salvato correttamente!"; //
    }

    private IEnumerator UpdateErLivello(int _livello)
    {
        var DBtask = DBReference.Child("users").Child(User.UserId).Child("livello").SetValueAsync(_livello);
        yield return new WaitUntil(predicate: () => DBtask.IsCompleted);

        if (DBtask.Exception != null)
            Debug.LogWarning(message: $"errore nell' aggiornare i dati {DBtask.Exception}");
    }

    private IEnumerator Register(string _email, string _password, string _username)
    {
        if (_username == "")
        {
            //If the username field is blank show a warning
            warningRegisterText.text = "Inserisci un username!";
        }
        else if (passwordRegisterField.text != passwordRegisterVerifyField.text)
        {
            //If the password does not match show a warning
            warningRegisterText.text = "Le password non coincidono!";
        }
        else
        {
            //Call the Firebase auth signin function passing the email and password
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(_email, _password);
            //Wait until the task completes
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null)
            {
                //If there are errors handle them
                Debug.LogWarning(message: $"Failed to register task with {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "Registrazione fallita!";
                switch (errorCode)
                {
                    case AuthError.MissingEmail:
                        message = "Inserisci la mail!";
                        break;
                    case AuthError.MissingPassword:
                        message = "Inserisci la password!";
                        break;
                    case AuthError.WeakPassword:
                        message = "Password troppo debole";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        message = "Questa email e' gia utilizzata!";
                        break;
                }
                warningRegisterText.text = message;
            }
            else
            {
                //User has now been created
                //Now get the result
                User = RegisterTask.Result;

                if (User != null)
                {
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile { DisplayName = _username };

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    //Wait until the task completes
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        //If there are errors handle them
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegisterText.text = "Username Set Failed!";
                    }
                    else
                    {
                        //Username is now set
                        //Now return to login screen
                        UIManager.instance.LoginScreen();
                        warningRegisterText.text = "";
                        Pulisci();
                    }
                }
            }
        }
    }


    private IEnumerator UpdateUsernameAuth(string _username)
    {
        UserProfile profile = new UserProfile { DisplayName = _username };

        var ProfileTask = User.UpdateUserProfileAsync(profile);

        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
        if (ProfileTask.Exception != null)
            Debug.LogWarning(message: $" errore nel registrare i dati con {ProfileTask.Exception}");

    }


    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        var DBtask = DBReference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);
        yield return new WaitUntil(predicate: () => DBtask.IsCompleted);

        if (DBtask.Exception != null)
            Debug.LogWarning(message: $" errore nel registrare i dati con {DBtask.Exception}");

    }

    private IEnumerator LoadUserData()
    {
        var DBtask = DBReference.Child("users").Child(User.UserId).GetValueAsync();
        yield return new WaitUntil(predicate: () => DBtask.IsCompleted);

        if (DBtask.Exception != null)
            Debug.LogWarning(message: $" errore nel registrare i dati con {DBtask.Exception}");
        else if (DBtask.Result.Value == null)
            livello = 0; // se non ha ancora nessun livello allora metti zero
        else
        {
            //e' bono 

            DataSnapshot snapshot = DBtask.Result;

            livello = int.Parse(snapshot.Child("livello").Value.ToString()); //cast string a int
            StartCoroutine(UpdateErLivello(1));
            SceneManager.LoadScene("cartellob");
           





        }
    }


    public int GetLivello()
    {
        return livelloMenu;
    }

    public void Salva1()
    {
        //StartCoroutine(UpdateUsernameDatabase(username));
        //StartCoroutine(UpdateUsernameAuth(username)); //update dell'username, anche se non credo si possa cambiare ma vabbe
       


        StartCoroutine(UpdateErLivello(2)); //update der livello

    }
}