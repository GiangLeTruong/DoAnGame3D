using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Skills_Box_Loader : MonoBehaviour
{
    bool isCreated = false;
    [SerializeField] GameObject[] this_Player_Skill_1 = new GameObject[2];
    [SerializeField] private TMP_Text text_Skill_1;

    [SerializeField] GameObject[] this_Player_Skill_2 = new GameObject[2];
    [SerializeField] private TMP_Text text_Skill_2;

    [SerializeField] GameObject[] this_Player_Skill_3 = new GameObject[2];
    [SerializeField] private TMP_Text text_Skill_3;

    [SerializeField] GameObject[] this_Player_Skill_4 = new GameObject[2];
    [SerializeField] private TMP_Text text_Skill_4;

    //Available Point:
    public TMP_Text available_SkillPoint;

    //Item Current Lever:
    public int level_Of_Skill_1;
    public int level_Of_Skill_2;
    public int level_Of_Skill_3;
    public int level_Of_Skill_4;


    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        if (isCreated == false)
        {
            generate_Icons(this.transform.tag);
            isCreated = true;
        }
        text_Skill_Editor();
       
    }
    void generate_Icons(string playerClass)
    {
        
        if (playerClass == "Warrior")
        {
            int class_Player=0;
            //Skill 1:
            float x = -0.23f, y = 0.14f, z = -0.4f;
            if (this_Player_Skill_1[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_1[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
            if (this_Player_Skill_2[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_2[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y-0.11f, z);
            }
            if (this_Player_Skill_3[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_3[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y-0.22f, z);
            }
            if (this_Player_Skill_4[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_4[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y-0.33f, z);
            }
        }
        else
        {
            int class_Player = 1;
            //Skill 1:
            float x = -0.23f, y = 0.14f, z = -0.4f;
            if (this_Player_Skill_1[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_1[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y, z);
            }
            if (this_Player_Skill_2[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_2[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y - 0.11f, z);
            }
            if (this_Player_Skill_3[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_3[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y - 0.22f, z);
            }
            if (this_Player_Skill_4[class_Player])
            {
                GameObject perfab = Instantiate(this_Player_Skill_4[class_Player], this.transform.position, this.transform.rotation);
                perfab.transform.SetParent(this.transform);
                perfab.transform.localScale = Vector3.one * 0.7f;
                perfab.transform.Translate(x, y - 0.33f, z);
            }
        }
    }
    void text_Skill_Editor()
    {
        switch (level_Of_Skill_1)
        {
            case 1:
                text_Skill_1.text = "+ Level 1: Cast distance 3m, deal 50 damage, cost 10 mana.";
                break;
            case 2:
                text_Skill_1.text = "+ Level 2: Cast distance 5m, deal 100 damage, cost 10 mana.";
                break;
            case 3:
                text_Skill_1.text = "+ Level Max: Cast distance 8m, deal 200 damage, cost 10 mana.";
                break;
            default:
                text_Skill_1.text = "Not Learn";
                break;
        }

        switch (level_Of_Skill_2)
        {
            case 1:
                text_Skill_2.text = "+ Level 1: Increases max health by 50hp and heals by 1 hp/s.";
                break;
            case 2:
                text_Skill_2.text = "+ Level 2: Increases max health by 100hp and heals by 2 hp/s.";
                break;
            case 3:
                text_Skill_2.text = "+ Level Max: Increases max health by 200hp and heals by 4 hp/s.";
                break;
            default:
                text_Skill_2.text = "Not Learn";
                break;
        }

        switch (level_Of_Skill_3)
        {
            case 1:
                text_Skill_3.text = "+ Level 1: Damage area 5m around the character, dealing 50 damage to all enemies in range.";
                break;
            case 2:
                text_Skill_3.text = "+ Level 2: Damage area 5m around the character, dealing 100 damage to all enemies in range.";
                break;
            case 3:
                text_Skill_3.text = "+ Level Max: Damage area 5m around the character, dealing 150 damage to all enemies in range.";
                break;
            default:
                text_Skill_3.text = "Not Learn";
                break;
        }

        switch (level_Of_Skill_4)
        {
            case 1:
                text_Skill_4.text = "+ Level 1: Swords that last for 10 seconds deal 50 damage per second to any enemy they touch.";
                break;
            case 2:
                text_Skill_4.text = "+ Level 2: Swords that last for 15 seconds deal 100 damage per second to any enemy they touch.";
                break;
            case 3:
                text_Skill_4.text = "+ Level Max: Swords that last for 20 seconds deal 200 damage per second to any enemy they touch.";
                break;
            default:
                text_Skill_4.text = "Not Learn";
                break;
        }
    }
    
}
