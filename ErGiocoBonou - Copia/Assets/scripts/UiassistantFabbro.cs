using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantFabbro : MonoBehaviour
{

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private int i;

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();

        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
        talkingAudioSource = transform.Find("talkingSound").GetComponent<AudioSource>();
        i = 0;

        transform.Find("message").GetComponent<Button_UI>().ClickFunc = () => {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                // Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[] {
                    "Alfo: Buongiorno Mastro Beppe, avrei bisogno di una spada",
                    "Mastro Beppe: E perché mai un giovine come te dovrebbe interessarsi di comprare un arma???",
                    "Hai forse qualche briga da risolvere con qualche ragazzaccio?!?!",
                    "Alfo: No hem... ecco... come posso spiegare?!?",
                    "Mastro Beppe: Non preoccuparti, ciò che devi fare non è' affar mio, allora,...per quanto riguarda la spada, oh si, prendi questa,",
                    "apparteneva a Flavio Romolo Augusto, è' la migliore che posseggo, ",
                    "l'ho rubata durante uno dei miei viaggi a sud IHIHIHIH, ma non dirlo a nessuno. ",
                    "Alfo: HAI RUBATO LA SPADA DI ROMOLO AUGUSTO?!?! MA COME?!?!? ",
                    "Mastro Beppe: SHHHHH o qualcuno ti sentirà, sei un bravo ragazzo, ti farò un buon prezz... ",
                    "Alfo: MA LA HAI RUBATA AL NOSTRO VECCHIO IMPERATORE!!! ",
                    "Mastro Beppe: Okok non c’è' bisogno di scaldarsi tanto, ufff d’accordo te la regalo AH AH AH,",
                     "vai ragazzo, non fare cose di cui potresti pentirti AH AH AH",
                    "e salutami BIANCA, è' da tanto che non la vedo qui al villaggio. ",
                    "-fai un cenno con la testa ed esci confuso dal negozio-",
                    "Alfo: ok è' giunto il momento di andare a prendere Bianca, chissà, se dopo tutti questi anni mi riconoscerà...",
                    "il crocevia non e' troppo lontano, spero di non incontrare pericoli nel mentre",
                    " "
                };

                string message = messageArray[i];
                if (i < 16)
                {
                    i++;
                }
                else 
                {
                    GameObject.FindGameObjectWithTag("Music 1").GetComponent<MusicClass>().StopMusic();
                    Button_do_thing("lupo");
                }

            
               
                    StartTalkingSound();
                
                
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .02f, true, true, StopTalkingSound);
               
            }
        };
    }

    private void StartTalkingSound()
    {
        talkingAudioSource.Play();
    }

    private void StopTalkingSound()
    {
        talkingAudioSource.Stop();
    }

    private void Start()
    {
        StopTalkingSound();
    }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }

}
