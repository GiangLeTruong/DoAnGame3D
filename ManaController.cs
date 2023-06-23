using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
using System.ComponentModel;
using UnityEditor;

public class ManaController : MonoBehaviour
{
    public GameObject Char;
    public int maxMana = 100;

    public int currenMana;

    // Regen per second:
    public int regenMana = 1;
    // This mean regen per delayTime.
    float delayTime = 1f;
    float nextRegen = 0f;
    public Slider sldMana;

    private void Start()
    {

        currenMana = maxMana;
    }

    private void Update()
    {
        // Set Mana bar.
        sldMana.maxValue = maxMana;
        sldMana.value = currenMana;

        if (currenMana > maxMana)
        {
            currenMana = maxMana;
        }
        RegenMana(); //Mana regen
    }


    void RegenMana()
    {
        if (Time.time >= nextRegen && Char.GetComponent<HealthController>().isDie == false)
        {
            if (currenMana < maxMana)
            {
                currenMana += regenMana;
            }
            else
            {
                currenMana = maxMana;
            }
            nextRegen = Time.time + delayTime;
        }

    }

    public void LostMana(int statima)
    {
        currenMana -= statima;
    }
}