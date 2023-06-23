using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Icon_Effect : MonoBehaviour
{
    GameObject This_Player;
    GameObject This_Image;

    public int Skill_Index;

    [SerializeField] bool isPassiveSkill;
    //Count Down:
    float countdown_skill_1;
    float countdown_skill_3;
    float countdown_skill_4;




    // Start is called before the first frame update
    void Start()
    {
        This_Player = GameObject.FindGameObjectWithTag("Warrior");
        This_Image = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        isCountDown(Skill_Index);
        if (isPassiveSkill)
        {
            if(This_Player.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level>0)
            {
                set_Normal_inmageEffect();
            }
            else
            {
                set_Gray_inmageEffect();
            }
        }
        else
        {
            switch (Skill_Index)
            {
                case 1:
                    if (This_Player.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level > 0)
                    {
                        if(countdown_skill_1>Time.time)
                        {
                            set_Gray_inmageEffect();
                        }
                        else
                        {
                            set_Normal_inmageEffect();
                        }
                    }
                    else
                    {
                        set_Gray_inmageEffect();
                    }
                    break;
                case 3:
                    if (This_Player.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level > 0)
                    {
                        if (countdown_skill_3 > Time.time)
                        {
                            set_Gray_inmageEffect();
                        }
                        else
                        {
                            set_Normal_inmageEffect();
                        }
                    }
                    else
                    {
                        set_Gray_inmageEffect();
                    }
                    break;
                case 4:
                    if (This_Player.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level > 0)
                    {
                        if (countdown_skill_4 > Time.time)
                        {
                            set_Gray_inmageEffect();
                        }
                        else
                        {
                            set_Normal_inmageEffect();
                        }
                    }
                    else
                    {
                        set_Gray_inmageEffect();
                    }
                    break;
            }
        }
    }

    void set_Gray_inmageEffect()
    {
        This_Image.GetComponent<SpriteRenderer>().color = Color.gray;
    }
    void set_Normal_inmageEffect()
    {
        This_Image.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void isCountDown(int skill_i)
    {
        if(This_Player.GetComponent<PlayerMovementAndAttack>())
        {
            if(skill_i == 1)
            {
                if (This_Player.GetComponent<PlayerMovementAndAttack>().isCasting_Skill_1)
                {
                    countdown_skill_1 = This_Player.GetComponent<PlayerMovementAndAttack>().skill_Timing;
                }
            }
            if (skill_i == 3)
            {
                if (This_Player.GetComponent<PlayerMovementAndAttack>().isCasting_Skill_3)
                {
                    countdown_skill_3 = This_Player.GetComponent<PlayerMovementAndAttack>().skill_Timing;
                }
            }
            if (skill_i == 4)
            {
                if (This_Player.GetComponent<PlayerMovementAndAttack>().isCasting_Skill_4)
                {
                    countdown_skill_4 = This_Player.GetComponent<PlayerMovementAndAttack>().skill_Timing;
                }
            }
        }
       
    }


}
