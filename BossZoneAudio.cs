using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZoneAudio : MonoBehaviour
{
    GameObject them_Song;
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag=="Warrior")
        {
            them_Song = GameObject.FindGameObjectWithTag("ThemeSong");
            them_Song.GetComponent<AudioSource>().volume = 0f;
        }
    }
    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "Warrior")
        {
            them_Song = GameObject.FindGameObjectWithTag("ThemeSong");
            them_Song.GetComponent<AudioSource>().volume = 1f;
        }
    }




}
