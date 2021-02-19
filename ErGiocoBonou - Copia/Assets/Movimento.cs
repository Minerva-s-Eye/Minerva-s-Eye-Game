using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    private Rigidbody2D rb;
    public float movespeed;
    private float moveInput;
    public float forzasalto;
    private bool isgrounded;
    public float deltaVelocita = 5.0f; // parametro che indica di quanto si avvicina il muro della morte verso l'alto
    public GameObject muroMorte;
    Animator animazione;
    private float altezzaPrecedente;
    public GameObject player;
    private bool precipita = false;
    Transform m_currMovingPlatform;

    void Start()
    {
        animazione = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isgrounded = false;
        altezzaPrecedente = -100;
        rb.mass = 100;
        rb.freezeRotation = true;
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0) && isgrounded == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.up * forzasalto;
            animazione.SetTrigger("salto");
            isgrounded = true;
            // animazione.SetTrigger("finesalto");
            // aaa   animazione.ResetTrigger("salto");

        }
        if (altezzaPrecedente > this.gameObject.transform.position.y && isgrounded == true)
        { //se il Player sta cadendo, però non sta su una piattaforma
            animazione.SetTrigger("precipita");
            precipita = true;
        }




        altezzaPrecedente = this.gameObject.transform.position.y;
        transform.position = new Vector3(0, this.gameObject.transform.position.y, 0); //in questo modo il player si muove solo veritcalmente

        // animazione.ResetTrigger("fineprecipita");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piattaforma") && precipita)
        {

            Transform m_currMovingPlatform = collision.gameObject.transform; //il player diventa child della piattaforma con cui collide
            transform.SetParent(m_currMovingPlatform);


            isgrounded = false;
            animazione.ResetTrigger("precipita");
            animazione.SetTrigger("fineprecipita");
            animazione.ResetTrigger("salto");
            animazione.SetTrigger("finesalto");
            precipita = false;


        }


        else if (collision.gameObject.CompareTag("Nemico")) //la collisione col nemico causa al giocatore l'impossibilità di saltare per 1 secondo
        {                                                   // oltre ad incrementare la velocita del muro della morte ( forse è troppo sgravato)
                                                            // *** NB IL NEMICO NON E' L'ANGELO MA LE PALLE DE FOCO ***

            muroMorte.GetComponent<FollowCharacter>().SetDeltaVelocita(0); // incremento velocità in multipli, esempio con 2 andrà al doppio
            StartCoroutine("Attendi"); //chiamata alla coroutine Attendi
            animazione.SetTrigger("colpito");
            animazione.SetTrigger("finecolpito");

        }
        else if (collision.gameObject.CompareTag("Boost")) //La collisione col boost fa rallentare il muro per 5 secondi
        {
            muroMorte.GetComponent<FollowCharacter>().SetDeltaVelocita(-2); //fa allontanare er boss
            muroMorte.GetComponent<FollowCharacter>().SetErBossColore(); // fa l'effetto colorato bellino ar boss
            StartCoroutine("AttendiBoost"); //Chiamata alla coroutine AttendiBoost
        }

        // ******** C A M B I O  S C E N A **********
        else if (collision.gameObject.CompareTag("FINE"))
        {
            
            Button_do_thing("pboss"); //frezza tutto
        }
        else if (collision.gameObject.CompareTag("angelo"))
        {
            
            Button_do_thing("ded 4"); //sartinculo
        }

    }
    IEnumerator Attendi() //funzione che dopo 1 secondo fa ritornare la velocita effettiva del muro al livello iniziale & riabilita il salto
    {
        isgrounded = true;
        yield return new WaitForSeconds(1);
        isgrounded = false;
        muroMorte.GetComponent<FollowCharacter>().SetDeltaVelocita(1);// ripristino velocità iniziale
    }
    IEnumerator AttendiBoost() //Probabilmete c'è un modo più ottimizzato per scrivere queste coroutine praticamente uguali
    {
        yield return new WaitForSeconds(4);
        muroMorte.GetComponent<FollowCharacter>().SetDeltaVelocita(1);// ripristino velocità iniziale

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Piattaforma")
            m_currMovingPlatform = null;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Piattaforma"))
            player.transform.parent = collision.gameObject.transform;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Piattaforma"))
            player.transform.parent = null;

    }

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }
}
