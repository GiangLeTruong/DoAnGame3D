using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonOnClick : MonoBehaviour
{
    private TMP_Text button_Text;
    private AudioSource button_Click;
    private void Start()
    {
        button_Text=this.GetComponent<TMP_Text>();
        //button_Click;
    }
    public void Onclick()
    {
        button_Text.fontSize = 40;
        button_Text.color= Color.black;
    }
}
