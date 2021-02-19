using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public float velocitaMovimento;
    public Vector3 offset;
    public Transform pedinato;
    Vector3 posizionePrecedente;
    float altezzaMassima;
    public float deltaVelocita=1;
   // public int contatore = 0;
    public float velocitaEffettiva;

    public GameObject erBoss;
    Color rosso = new Color(1, 0, 0, 1);
    Color bianco = new Color(1, 1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
       // offset = transform.position - pedinato.position;
        posizionePrecedente.y = -100; //valore random iniziale basso senno sbrocca
        altezzaMassima = 0;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        Vector3 posizioneObiettivo = pedinato.position + offset;
       


        posizioneObiettivo.x = transform.position.x; //cosi nse sposta di lato ma solo su asse y
        if (posizioneObiettivo.y > posizionePrecedente.y && (pedinato.position.y > altezzaMassima))
        { //se nel frame precedente er player era piu in basso, allora seguilo
            transform.position += posizioneObiettivo - transform.position;
            altezzaMassima = transform.position.y+8; //8 è scelto abbastanza random, è necessario altrimenti il muro andrebbe a toccare il pedinato subito
        }
        
         offset.Set(0, transform.position.y - pedinato.position.y, 0); // ripristino l'offset, senza questo come il player tocca una piattaforma il muro scatta indietro
        posizionePrecedente.y = posizioneObiettivo.y; 

        
        Translazione();
         
    }

    public void SetDeltaVelocita(float numero)
    {
        this.deltaVelocita = numero;
        
    }

    public void SetErBossColore() // volendo si poteva mettere il colore come argomento ma tanto mi serve solo rosso
    {
        
        erBoss.GetComponent<SpriteRenderer>().color = rosso;
        StartCoroutine("CambiaColoreBianco");
        erBoss.GetComponent<SpriteRenderer>().color = rosso;
        StartCoroutine("CambiaColoreRosso");
        StartCoroutine("CambiaColoreBianco");
        StartCoroutine("CambiaColoreRosso");
        StartCoroutine("CambiaColoreBianco"); //non so perchè lo fa una sola botta.. ciccia
    }

    IEnumerator CambiaColoreBianco()
    {
        yield return new WaitForSeconds(0.5f);
        erBoss.GetComponent<SpriteRenderer>().color = bianco;

    }

    IEnumerator CambiaColoreRosso()
    {
        yield return new WaitForSeconds(0.5f);
        erBoss.GetComponent<SpriteRenderer>().color = rosso;

    }

    public float GetDeltaVelocita()
    {
        return this.deltaVelocita;
    }

    public void Translazione() //questo fa muovere il muro della morte (velocita costante)
    {
        velocitaEffettiva = velocitaMovimento * deltaVelocita;
        transform.Translate(0, velocitaEffettiva, 0);
    }

    public void IncreaseCounter()
    {
       // this.contatore++;
    }
}
