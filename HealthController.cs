using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System.Drawing;
using Random = UnityEngine.Random;
using UnityEngine.Animations.Rigging;
using System.Threading;

public class HealthController : MonoBehaviour
{
    public GameObject this_Character;
    public int maxHealth = 100;
    //control realtime;
    //public GameObject controlRealtime;
    public int currenHealth;
    // Regen per second:
    public int regenHealth = 1;
    // This mean regen per delayTime.
    float delayTime = 1f;
    float nextRegen = 0f;
    public Slider this_Character_sldHealth;
    [SerializeField]  private GameObject floating_text_Damage;
    // Dead animation:
    public Animator this_Character_Animator;
    public bool isDie = false;
    float dyingDuration = 10f; // This mean char will play die anim in x second(s) then destroy.
    float letDie = 0f;
    // Hurt FX:
    public ParticleSystem this_Character_BleadingFX;
    // Audio:
    public AudioSource this_Character_AudioHurt;
    public AudioSource this_Character_AudioDie;

    private void Start()
    {
        currenHealth = maxHealth;
    }

    private void Update()
    {
        // Set Health bar.
        this_Character_sldHealth.maxValue = maxHealth;
        this_Character_sldHealth.value = currenHealth;
        RegenHealth(); //Health regen
        if (currenHealth > maxHealth)
        {
            currenHealth = maxHealth;
        }
        
        // Check die:
        ClearObject();
    }

    void RegenHealth()
    {
        if (Time.time >= nextRegen && currenHealth < maxHealth)
        {
            if (currenHealth < maxHealth && isDie == false)
            {
                currenHealth += regenHealth;
            }
            else
            {
                currenHealth = maxHealth;
            }
            nextRegen = Time.time + delayTime;
        }
    }

    public void TakeDamge(int damage)
    {
        if (isDie == false)
        {
            currenHealth -= damage;
        //Die function:
        if (currenHealth <= 0)
        {
            Die();
            isDie = true;
        }
        else
        {
            //Play hurt animation:
            this_Character_BleadingFX.Play();
            show_text_TakeDamge(damage);
            this_Character_Animator.SetTrigger("isHurt");
            //Play audio:
            this_Character_AudioHurt.Play();
        }
        }
    }
    void show_text_TakeDamge(int damagePoint)
    {
       if(floating_text_Damage)
        {
            GameObject perfab = Instantiate(floating_text_Damage, new Vector3(this_Character_sldHealth.transform.position.x, this_Character_sldHealth.transform.position.y+0.4f, this_Character_sldHealth.transform.position.z),new Quaternion(this_Character_sldHealth.transform.rotation.x, this_Character_sldHealth.transform.rotation.y, this_Character_sldHealth.transform.rotation.z, this_Character_sldHealth.transform.rotation.w));
            perfab.GetComponentInChildren<TextMesh>().text = "-"+damagePoint.ToString();
        }
    }
    void Die()
    {
        //Die anim:
        this_Character_Animator.Play("Death");
        //Play audio:
        this_Character_BleadingFX.Stop();
        this_Character_AudioHurt.Stop();
        this_Character_AudioDie.Play();
        //Clear Object:
        letDie = Time.time + dyingDuration;
       
    }
    void ClearObject()
    {
        if(this_Character_sldHealth)
        {
            if (isDie == true && this_Character.gameObject.tag != "Warrior")
            {
                Destroy(this_Character_sldHealth.gameObject);
            }
        }
        if (isDie == true && Time.time >= letDie)
        {
            if (this_Character.gameObject.tag == "Warrior")
            {
                if (this.GetComponent<UISystem>())
                {
                    Cursor.visible = true;
                    this.GetComponent<PlayerMovementAndAttack>().enabled = false;
                    this.transform.GetChild(7).GetComponent<CameraFollow>().enabled = false;
                    this.GetComponent<UISystem>().isOnTab = true;
                    this.GetComponent<UISystem>().ui_GameOver.SetActive(true);
                }

            }
            else
            {
                if(this_Character.gameObject.tag == "Boss")
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Warrior");
                    if (player.GetComponent<UISystem>())
                    {
                        Cursor.visible = true;
                        player.GetComponent<PlayerMovementAndAttack>().enabled = false;
                        player.transform.GetChild(7).GetComponent<CameraFollow>().enabled = false;
                        player.GetComponent<UISystem>().isOnTab = true;
                        player.GetComponent<UISystem>().ui_EndGame.SetActive(true);
                    }
                }
                Destroy(this_Character);
            }

        }
    }
}