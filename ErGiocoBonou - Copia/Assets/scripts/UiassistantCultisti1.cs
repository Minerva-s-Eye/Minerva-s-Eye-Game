using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantCultisti1 : MonoBehaviour
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
                    "Bianca: ... sono morti, tutti",
                    " ... ma tu non ti fermerai, vero?",
                    "Alfo: ... no",
                    "Bianca: non ci sta niente che possa farti cambiare idea, giusto?",
                    "Alfo: . . .",
                    "Bianca: ... va bene. Addio, fratello mio ",
                    " "
                };

                string message = messageArray[i];
                if (i < 6)
                {
                    i++;
                }
                else 
                {
                    Button_do_thing("bbutton 2");
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
