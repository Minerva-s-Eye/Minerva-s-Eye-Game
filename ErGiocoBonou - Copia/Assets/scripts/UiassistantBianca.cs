using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantBianca : MonoBehaviour
{

    private Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource talkingAudioSource;
    private int i;

    private void Awake()
    {

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
                    "Alfo: Sono arrivato, sono sicuro che il villaggio sia questo non mi resta che trovare Bian...",
                    "“?”: Ciao forestiero, non ricordo di averti mai visto da queste parti...",
                    "Alfo: Mi presento, il mio nome è Alfo e vengo dal villagio a sud di qui",
                    "“?”: E sentiamo un po, cosa saresti venuto a fare?",
                    "Alfo: Sto cercando una donna di nome Bianca",
                    "“?”: Bianca?   ...   Non ho idea di chi sia, e ora sparisci. ",
                    "Alfo: Non uscirò di qui finché non vedrò Bianca. ",
                    "“?”: E allora resta qui ma sappi che stiamo evacuando il villaggio,",
                    "presto i Cultisti lo assedieranno, se resti,muori. ",
                    "Alfo: Ripeto, senza Bianca io non mi muovo di...",
                    "“?”: Perché fai questo? Perché tanta ossessione per questa persona?",
                    "Alfo: Perché è' mia sorella e devo riportarla da madre, la troverò ad ogni costo.",
                    "Nonostante abbia lasciato me e mia madre da soli, nelle sue vene scorre il mio stesso sangue,",
                    "è' mia sorella, e la salverò da questa follia.",
                    " "

                };

                string message = messageArray[i];
                if (i < 14)
                {
                    i++;
                }
                else 
                {
                    Button_do_thing("fabbro 2");
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
