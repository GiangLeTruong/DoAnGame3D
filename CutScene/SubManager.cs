using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class SubManager : MonoBehaviour
{
    [SerializeField] float introTime;
    float time_Counting = 0f;
    [SerializeField] TMP_Text ui_text_Sub;
    //Audio Voice Stack:
    [SerializeField] GameObject[] voice_Sub;
    [SerializeField] GameObject battleField_audio;
    [SerializeField] GameObject fire_audio;










    // Update is called once per frame
    void Update()
    {
        time_Counting += Time.deltaTime;
        text_Editor();
    }

    void text_Editor()
    {
        if(time_Counting>=5+ introTime && time_Counting <= 17+ introTime)//5
        {
            voice_Sub[0].SetActive(true);
            ui_text_Sub.text = "Before... there was a peaceful village... where everyone lived in harmony and happiness.";
        }
        else if (time_Counting > 17 + introTime && time_Counting <= 23 + introTime)//5
        {
            voice_Sub[1].SetActive(true);
            ui_text_Sub.text = "But one day, a portal to hell suddenly opened, shattering the peaceful atmosphere.";
        }
        else if (time_Counting > 23 + introTime && time_Counting <= 35 + introTime)//10
        {
            voice_Sub[2].SetActive(true);
            ui_text_Sub.text = "The dim lights of the crimson flames shone everywhere, bringing with it menace and chaos. The villagers are caught up in the battle against the evil forces they have never experienced.";
           
        }
        else if (time_Counting > 35 + introTime && time_Counting <= 42 + introTime)//5
        {
            battleField_audio.SetActive(true);
            fire_audio.SetActive(true);
            voice_Sub[3].SetActive(true);
            ui_text_Sub.text = "Despite their best efforts, the villagers could not resist the devastation and destruction.";
        }
        else if (time_Counting > 42 + introTime && time_Counting <= 48 + introTime)//5
        {
            voice_Sub[4].SetActive(true);
            ui_text_Sub.text = "Flames have consumed houses, brutal monsters have defeated the brave.";
        }
        else if (time_Counting > 48 + introTime && time_Counting <= 54 + introTime)//5
        {
            voice_Sub[5].SetActive(true);
            ui_text_Sub.text = "Hope fades and vanishes, leaving only a feeling of disappointment and despair in people's souls.";
        }
        else if (time_Counting > 54 + introTime && time_Counting <= 60 + introTime)//5
        {
            battleField_audio.SetActive(false);
            fire_audio.SetActive(false);
            voice_Sub[6].SetActive(true);
            ui_text_Sub.text = "But... at the most difficult moment, a hero appeared.";
        }
        else if (time_Counting > 62 + introTime && time_Counting <= 75 + introTime)//10
        {
            voice_Sub[7].SetActive(true);
            ui_text_Sub.text = "With ancient magic from the gods, he faced monsters and fought. In the bright white light, the hero does not stop fighting, sowing hope in people's hearts.";
        
            if(time_Counting > 72 + introTime && time_Counting <= 75 + introTime)
            {
                battleField_audio.SetActive(true);
                fire_audio.SetActive(true);
            }
        }
        else if (time_Counting > 75 + introTime && time_Counting <= 81 + introTime)//5
        {
            voice_Sub[8].SetActive(true);
            ui_text_Sub.text = "Let's step into this game where hope remains and the hero's strength will determine fate.";
        }
        else if (time_Counting > 81 + introTime && time_Counting <= 88 + introTime)//7
        {
            battleField_audio.SetActive(false);
            fire_audio.SetActive(false);
            voice_Sub[9].SetActive(true);
            ui_text_Sub.text = "An arduous and difficult journey awaits, but it is sure to bring excitement and exciting discovery.";
        }
        else if (time_Counting > 92+ introTime)//7
        {
            ui_text_Sub.text = "The character and weapon assets:\r\nPolygon Fantasy Rivals by Synty Studios™\r\nPolygonal Fantasy Pack by Meshtint Studio\r\n\r\nEffects from:\r\nAC Little Enchant Mesh VFX by Alphaime Corporation\r\nMagic effects pack by Hovl Studio\r\n\r\nMusic:\r\n\"Reign of the Dark\" by Adrian von Ziegler\r\n\"Epic Adventure\" from the Youtube\n\n\nClick SKIP to star your Game!";
        }




        /*
        else if(time_Counting > 10 + introTime && time_Counting <= 15 + introTime)//5
        {
            voice_Sub[1].SetActive(true);
            ui_text_Sub.text = "But one day, a portal to hell suddenly opened, shattering the peaceful atmosphere.";
        }
        else if (time_Counting > 15 + introTime && time_Counting <= 25 + introTime)//10
        {
            voice_Sub[2].SetActive(true);
            ui_text_Sub.text = "The dim lights of the crimson flames shone everywhere, bringing with it menace and chaos. The villagers are caught up in the battle against the evil forces they have never experienced.";
        }
        else if (time_Counting > 25 + introTime && time_Counting <= 30 + introTime)//5
        {
            voice_Sub[3].SetActive(true);
            ui_text_Sub.text = "Despite their best efforts, the villagers could not resist the devastation and destruction.";
        }
        else if (time_Counting > 30 + introTime && time_Counting <= 35 + introTime)//5
        {
            voice_Sub[4].SetActive(true);
            ui_text_Sub.text = "Flames have consumed houses, brutal monsters have defeated the brave.";
        }
        else if (time_Counting > 35 + introTime && time_Counting <= 40 + introTime)//5
        {
            voice_Sub[5].SetActive(true);
            ui_text_Sub.text = "Hope fades and vanishes, leaving only a feeling of disappointment and despair in people's souls.";
        }
        else if (time_Counting > 40 + introTime && time_Counting <= 45 + introTime)//5
        {
            voice_Sub[6].SetActive(true);
            ui_text_Sub.text = "But... at the most difficult moment, a hero appeared.";
        }
        else if (time_Counting > 45 + introTime && time_Counting <= 55 + introTime)//10
        {
            voice_Sub[7].SetActive(true);
            ui_text_Sub.text = "With ancient magic from the gods, he faced monsters and fought. In the bright white light, the hero does not stop fighting, sowing hope in people's hearts.";
        }
        else if (time_Counting > 55 + introTime && time_Counting <= 60 + introTime)//5
        {
            voice_Sub[8].SetActive(true);
            ui_text_Sub.text = "Let's step into this game where hope remains and the hero's strength will determine fate.";
        }
        else if (time_Counting > 60 + introTime && time_Counting <= 67 + introTime)//7
        {
            voice_Sub[9].SetActive(true);
            ui_text_Sub.text = "An arduous and difficult journey awaits, but it is sure to bring excitement and exciting discovery.";
        }
        */

    }






}
