using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Button_ChangeScene : MonoBehaviour
{
    [SerializeField] private TMP_Text button_NewGame_Text;
    [SerializeField] private TMP_Text button_Continue_Text;
    [SerializeField] private AudioSource button_Click;
    [SerializeField] GameObject MainMenu_Opt;
    public void button_ChangeScene_NewGame(string scenename)
    {
        MainMenu_Opt.GetComponent<MainMenuOptions>().isNewGame = true;
        SceneManager.LoadScene(scenename);
        Onclick(button_NewGame_Text);
    }
    public void button_ChangeScene_LoadGame(string scenename)
    {
        MainMenu_Opt.GetComponent<MainMenuOptions>().isNewGame = false;
        SceneManager.LoadScene(scenename);
        Onclick(button_Continue_Text);
    }
    public void button_Skip_CutScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }



    void Onclick(TMP_Text text_TMP)
    {
        text_TMP.fontSize = 40;
        text_TMP.color = Color.red;
        button_Click.Play();
    }

}
