using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantBianca1 : MonoBehaviour
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
                    "Bianca: Fratello mio...scusami io...io non ti avevo riconosciuto...",
                    "sono passati troppi anni, io non sapevo...",
                    "Alfo: Tu sei, tu sei...Bianca?...Davvero?",
                    "- travolto dalle emozion, abbracci forte tua sorella -",
                    "Alfo: Dobbiamo andare, mamma ci sta aspettando.",
                    "Bianca: D’accordo, prendo le mie cose e fuggiamo di qui.",
                    " "

                };

                string message = messageArray[i];
                if (i < 6)
                {
                    i++;
                }
                else 
                {
                    GameObject.FindGameObjectWithTag("Music3").GetComponent<MusicClass>().StopMusic();
                    Button_do_thing("Unity project");
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
