using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System.Timers;

public class UiassistantBasilica : MonoBehaviour
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
                    "....Benvenuto, umano",
                    "Cio che trovi dinnanzi a te e' il creatore di questo universo intero",
                    "Quando fui sconfitto, eoni fa, ho perso la spada di Damocle e sono stato separato dal mio corpo",
                    "Tutto ciò che hai vissuto in questo tempo non è altro che una proiezione della mia maestosa mente! ",
                    "Ma non appena oggi riuscirò a ricompletare la spada, tornerò ad essere cio che sono sempre stato",
                    "tornerò ad essere",
                    " ",
                    " "
                };

                string message = messageArray[i];
                if (i < 6)
                {
                    i++;
                }
                else 
                {
                    Button_do_thing("tboss");
                }


               



                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, null);
               
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

    private void Start() {
        StopTalkingSound();
        GameObject.FindGameObjectWithTag("Music2").GetComponent<MusicClass>().PlayMusic();
        StartTalkingSound();
    }
   

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }

}
