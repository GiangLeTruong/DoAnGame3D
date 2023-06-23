using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
using System.ComponentModel;
using UnityEditor;

public class EXPController : MonoBehaviour
{
    public GameObject Char;
    public int currentEXP;
    public int maxEXP;
   
    [SerializeField] Slider sldEXP;
    // Hurt FX:
    public ParticleSystem this_Character_LeveleUpFX;
    // Audio:
    public AudioSource this_Character_AudioLeveleUp;

    private void Update()
    {
        // Set EXP bar.
        set_EXP();



    }
    private void set_EXP()
    {
        sldEXP.maxValue = maxEXP;
        sldEXP.value = currentEXP;
        //Set FX:
        if(currentEXP>= maxEXP)
        {
            this_Character_LeveleUpFX.Play();
            this_Character_AudioLeveleUp.Play();
        }


    }




}