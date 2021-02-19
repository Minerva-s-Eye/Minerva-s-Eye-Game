using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using System.Timers;

public class UiassistantBasilica1 : MonoBehaviour
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
                    "IO SONO L'INCARNAZIONE DELLA VOLONTA' DIVINA",
                    "PREPARATI, PERCHE' OGGI SPARIRAI PER MANO DELL'OCCHIO DI MINERVA",
                    " "
                };

                string message = messageArray[i];
                if (i < 2)
                {
                    
                    i++;
                }
                else 
                {
                    Button_do_thing("SampleSceneee");
                    GameObject.FindGameObjectWithTag("Music2").GetComponent<MusicClass>().StopMusic();
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
        Timer timer = new Timer(1000);
        StopTalkingSound();
        timer.Start();
        System.Threading.Thread.Sleep(3000);

        StartTalkingSound();
    }
   

    public void Button_do_thing(string nomeScena)
    {
        SceneManager.LoadScene(nomeScena);
    }

}
