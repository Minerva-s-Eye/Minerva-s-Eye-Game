
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class Uiassistanti : MonoBehaviour
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
                    "Tanto tempo fa, poco dopo la caduta dell’Impero Romano D’Occidente, in una serie di villaggi a nord di Ravenna, le macchinazioni di un oscura e antica entità cominciarono a sconvolgere la pace che perpetuava tra gli abitanti. Un gruppo di Cultisti, grandi fedeli della “Basilica di Santa Vitae” a nord del paese cominciò a razziare e bruciare i villaggi limitrofi alla ricerca di qualcosa, qualcosa di prezioso, andato in pezzi diversi secoli prima...",
                    " "
                    

                };

                string message = messageArray[i];
                if (i < 1)
                {
                    i++;
                }
                else
                {
                    Button_do_thing("menu");
                }



                StartTalkingSound();


                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, .05f, true, true, StopTalkingSound);

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

