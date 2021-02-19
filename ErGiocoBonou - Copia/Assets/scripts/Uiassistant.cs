using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class Uiassistant : MonoBehaviour
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
                    "Alfo: ... dunque i Cultisti di Santa Vitae stanno...",
                    "no, non posso crederci, non dovrebbe succedere!",
                    "Madre: Devi andare nel villaggio di tua sorella, portala qui,",
                    " è' sola e non so cosa potrei fare se le succedesse qualcosa…",
                    "Alfo: D’accordo, farò di tutto pur di proteggerla!",
                    "Madre: Grazie, figlio mio... grazie. -tua madre scoppia in lacrime- ",
                    " "
                 
                };

                string message = messageArray[i];
                if (i < 6)
                {
                    i++;
                }
                else 
                {
                    Button_do_thing("SampleScene 1");
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
