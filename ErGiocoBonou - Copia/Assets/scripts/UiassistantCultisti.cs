using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantCultisti : MonoBehaviour
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
                    "I tuoi occhi sono ancora in lacrime, quando li vedi in lontananza",
                    "I Cultisti ",
                    "Bianca: dobbiamo andare fratello, stanno arrivando anche per noi",
                    "Alfo: ... no",
                    "Bianca: fratello, per favore, andiamo!",
                    "Alfo: NO, DEVONO MORIRE",
                    "Bianca: ti prego...  -bianca inizia a piangere- ",
                    " "
                };

                string message = messageArray[i];
                if (i < 7)
                {
                    i++;
                }
                else 
                {
                    Button_do_thing("bbutton 1");
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
