using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject this_Player;
    private string this_PlayerClass;
    [SerializeField] private Slider slider_HealthBar;
    [SerializeField] private TMP_Text text_HealthBar;

    [SerializeField] private Slider slider_ManaBar;
    [SerializeField] private TMP_Text text_ManaBar;

    [SerializeField] private Slider slider_EXPBar;
    [SerializeField] private TMP_Text text_EXPBar;


    [SerializeField] GameObject[] this_Player_Avatar=new GameObject[3];
    [SerializeField] GameObject[] this_Player_Skill_1=new GameObject[3];
    [SerializeField] GameObject[] this_Player_Skill_2 = new GameObject[3];
    [SerializeField] GameObject[] this_Player_Skill_3 = new GameObject[3];
    [SerializeField] GameObject[] this_Player_Skill_4 = new GameObject[3];








    // Start is called before the first frame update
    void Start()
    {
        this_PlayerClass = this_Player.gameObject.transform.tag;
        generate_Avartar(this_PlayerClass);
        generate_SkillIcons_1(this_PlayerClass);
        generate_SkillIcons_2(this_PlayerClass);
        generate_SkillIcons_3(this_PlayerClass);
        generate_SkillIcons_4(this_PlayerClass);


    }
    private void Update()
    {
        set_HealthBar();
        set_ManaBar();
        set_EXPBar();
    }
    void set_HealthBar()
    {
        text_HealthBar.text= slider_HealthBar.value.ToString()+"/"+ slider_HealthBar.maxValue.ToString();
    }
    void set_ManaBar()
    {
        text_ManaBar.text = slider_ManaBar.value.ToString() + "/" + slider_ManaBar.maxValue.ToString();
    }

    void set_EXPBar()
    {
        text_EXPBar.text = "EXP: "+slider_EXPBar.value.ToString() + "/" + slider_EXPBar.maxValue.ToString();
    }


    void generate_Avartar(string playerClass)
    {
        float x= -0.6783f, y= 0.343f, z= 0;
        if(playerClass=="Warrior")
        {
            if (this_Player_Avatar[0])
            {
                GameObject perfab = Instantiate(this_Player_Avatar[0], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale= Vector3.one*0.7f;
                perfab.transform.Translate(x,y,z);
            }
        }
        else if (playerClass == "Berserker")
        {
            if (this_Player_Avatar[1])
            {
                GameObject perfab = Instantiate(this_Player_Avatar[1], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }

        }
        else
        {
            if (this_Player_Avatar[2])
            {
                GameObject perfab = Instantiate(this_Player_Avatar[2], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }

        }

    }

    void generate_SkillIcons_1(string playerClass)
    {
        float x = -0.175f, y = -0.355f, z = -0.001f;
        if (playerClass == "Warrior")
        {
            if (this_Player_Skill_1[0])
            {
                GameObject perfab = Instantiate(this_Player_Skill_1[0], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Berserker")
        {
            if (this_Player_Skill_1[1])
            {
                GameObject perfab = Instantiate(this_Player_Skill_1[1], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Marksman")
        {
            if (this_Player_Skill_1[2])
            {
                GameObject perfab = Instantiate(this_Player_Skill_1[2], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
    }
    void generate_SkillIcons_2(string playerClass)
    {
        float x = -0.058f, y = -0.355f, z = -0.001f;
        if (playerClass == "Warrior")
        {
            if (this_Player_Skill_2[0])
            {
                GameObject perfab = Instantiate(this_Player_Skill_2[0], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Berserker")
        {
            if (this_Player_Skill_2[1])
            {
                GameObject perfab = Instantiate(this_Player_Skill_2[1], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Marksman")
        {
            if (this_Player_Skill_2[2])
            {
                GameObject perfab = Instantiate(this_Player_Skill_2[2], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }

    }
    void generate_SkillIcons_3(string playerClass)
    {
        float x = 0.058f, y = -0.355f, z = -0.001f;
        if (playerClass == "Warrior")
        {
            if (this_Player_Skill_3[0])
            {
                GameObject perfab = Instantiate(this_Player_Skill_3[0], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Berserker")
        {
            if (this_Player_Skill_3[1])
            {
                GameObject perfab = Instantiate(this_Player_Skill_3[1], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Marksman")
        {
            if (this_Player_Skill_3[2])
            {
                GameObject perfab = Instantiate(this_Player_Skill_3[2], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }

    }
    void generate_SkillIcons_4(string playerClass)
    {
        float x = 0.175f, y = -0.355f, z = -0.001f;
        if (playerClass == "Warrior")
        {
            if (this_Player_Skill_4[0])
            {
                GameObject perfab = Instantiate(this_Player_Skill_4[0], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Berserker")
        {
            if (this_Player_Skill_4[1])
            {
                GameObject perfab = Instantiate(this_Player_Skill_4[1], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }
        else if (playerClass == "Marksman")
        {
            if (this_Player_Skill_4[2])
            {
                GameObject perfab = Instantiate(this_Player_Skill_4[2], this.transform.position, Quaternion.identity);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
        }


    }






}

