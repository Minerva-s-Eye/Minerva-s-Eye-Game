using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class UiassistantSud : MonoBehaviour
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
                    "Madre: Cosa ci fai qui?!? Bianca è in pericolo!!!",
                    "Alfo: Non ora madre, devo prendere una cos…",
                    "HAAAAAAAAAAAA  -senti molte urla strazianti-",
                    "Alfo: ma... queste urla... No! Devono essere i cultisti!",
                    "Dannazione, loro sono gia qui…scappiamo madre...madre cosa stai??",
                    "Madre: Le mie gambe non si muovono, ho paura! E bianca...",
                    "Alfo: Dobbiamo rifugiarci da mastro Beppe, la sua cantina è un luogo sicuro,",
                    "sono sicuro che i cultisti non la troveranno ",
                    "Madre: Bianca...Bianca… ",
                    "Alfo: Smettila madre, andremo da Bianca dopo che ci saremo messi in salvo",
                    " "

                };

                string message = messageArray[i];
                if (i < 10)
                {
                    i++;
                }
                else 
                {
                    
                    Button_do_thing("nerooo");
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
