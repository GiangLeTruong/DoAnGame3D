using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skills_Manager : MonoBehaviour
{
    //Set Object:
    [SerializeField] GameObject this_Player;
    //Set Object:
    [SerializeField] GameObject this_Player_Bottom;
    GameObject this_Casting_Point;
    [SerializeField] float this_CastingPoint_Height=0f;
    [SerializeField] GameObject this_Cammera;
    //Set Transform:
    Transform this_CastingPoint_Transform;
   

    [SerializeField] float fx_speed = 0f;
    [SerializeField] GameObject[] object_Skills=new GameObject[3];

    //Skill_1 FX effect:
    [SerializeField] GameObject Circle_effect_Skill_2;
    [SerializeField] GameObject Portal_effect_Skill_3;

    //Skill_2 Detecting:
    bool isCreate_Skill_2=false;

    //Skill_3 counting:
    bool star_Counting_Skill_3=false;
    bool isCreated = false;
    float calling_MeteorRain=0f;
    [SerializeField] float wait_for_MeteorRain;
    [SerializeField] float duration_MeteorRain;

    //Skill Call:
    //Skill 1:
    public int Skill_1_Casting = 0;
    private float timer_NextSlash=0;
    //Skill 2:
    public bool Skill_2_Casting=false;
    //Skill 3:
    public bool Skill_3_Casting = false;
    //Skill 4:
    public bool Skill_4_Casting = false;


    // Start is called before the first frame update
    void Start()
    {
        this_Casting_Point=this.gameObject;
        this_CastingPoint_Transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        using_Skill_Controller();
        if(star_Counting_Skill_3)
        {
            calling_MeteorRain+=Time.deltaTime;
        }
        else
        {
            calling_MeteorRain = 0f;
        }
    }

    private void using_Skill_Controller()
    {
        if (this_Casting_Point)
        {
            //Play skill 1:
            if (Skill_1_Casting >=1)
            {
                timer_NextSlash += Time.deltaTime;
                if(Skill_1_Casting>3)
                {
                    Skill_1_Casting = 0;
                    timer_NextSlash = 0;
                }
                else
                {
                    //Slash number 1 (0.55s - Angle: 45):
                    if (Skill_1_Casting ==1&& timer_NextSlash>=0.55f)
                    {
                        var skill_1_1 = Instantiate(object_Skills[0], new Vector3(this_Player_Bottom.transform.position.x, this_Player_Bottom.transform.position.y + 1.5f, this_Player_Bottom.transform.position.z), this_Player_Bottom.transform.rotation);
                        skill_1_1.GetComponent<TimeToLive>().time_ToLive = this_Player.GetComponent<CharacterProLoader>().skill_1_TimeTolive;
                        skill_1_1.GetComponent<Skill_Effect_Brain>().this_EffectDamage = this_Player.GetComponent<CharacterProLoader>().skill_1_deal_Damage;
                        skill_1_1.transform.Rotate(0,0,45);
                        skill_1_1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fx_speed * Time.deltaTime * 50);
                        skill_1_1.GetComponent<ParticleSystem>().Play();
                        Skill_1_Casting += 1;
                    }

                    //Slash number 2 (1.25 - Angle: 30):
                    if (Skill_1_Casting == 2 && timer_NextSlash >= 1.25f)
                    {
                        var skill_1_2 = Instantiate(object_Skills[0], new Vector3(this_Player_Bottom.transform.position.x, this_Player_Bottom.transform.position.y + 1.5f, this_Player_Bottom.transform.position.z), this_Player_Bottom.transform.rotation);
                        skill_1_2.GetComponent<TimeToLive>().time_ToLive = this_Player.GetComponent<CharacterProLoader>().skill_1_TimeTolive;
                        skill_1_2.GetComponent<Skill_Effect_Brain>().this_EffectDamage = this_Player.GetComponent<CharacterProLoader>().skill_1_deal_Damage;
                        skill_1_2.transform.Rotate(0, 0, 0);
                        skill_1_2.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fx_speed * Time.deltaTime * 50);
                        skill_1_2.GetComponent<ParticleSystem>().Play();
                        Skill_1_Casting += 1;
                    }
                    //Slash number 3 (2.25 - Angle: 95):
                    if (Skill_1_Casting == 3 && timer_NextSlash >= 2.25f)
                    {
                        var skill_1_3 = Instantiate(object_Skills[0], new Vector3(this_Player_Bottom.transform.position.x, this_Player_Bottom.transform.position.y + 1.5f, this_Player_Bottom.transform.position.z), this_Player_Bottom.transform.rotation);
                        skill_1_3.GetComponent<TimeToLive>().time_ToLive = this_Player.GetComponent<CharacterProLoader>().skill_1_TimeTolive;
                        skill_1_3.GetComponent<Skill_Effect_Brain>().this_EffectDamage = this_Player.GetComponent<CharacterProLoader>().skill_1_deal_Damage;
                        skill_1_3.transform.Rotate(0, 0, 95);
                        skill_1_3.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * fx_speed * Time.deltaTime * 50);
                        skill_1_3.GetComponent<ParticleSystem>().Play();
                        Skill_1_Casting += 1;
                    }
                }
            }
            if (Skill_2_Casting)
            {
                if(isCreate_Skill_2==false)
                {
                    var effect_skill_2 = Instantiate(Circle_effect_Skill_2, this_Player_Bottom.transform.position, this_Player_Bottom.transform.rotation);
                    effect_skill_2.transform.parent = this_Player_Bottom.transform;
                    isCreate_Skill_2 = true;
                }
                
            }
            if (Skill_3_Casting)
            {
                isCreated = false;
                //Open portal:
                var portal_skill_3 = Instantiate(Portal_effect_Skill_3, this_Player_Bottom.transform.position, this_Player_Bottom.transform.rotation);
                Destroy(portal_skill_3, wait_for_MeteorRain+duration_MeteorRain+1.5f);
                //Counting for Meotreo Rain:
                star_Counting_Skill_3 = true;
                Skill_3_Casting = false;
            }
            if (Skill_4_Casting)
            {
                //Create Great Sword:
                var skill_4 = Instantiate(object_Skills[2], this_Player_Bottom.transform.position, this_Player_Bottom.transform.rotation);
                skill_4.GetComponent<TimeToLive>().time_ToLive= this_Player.GetComponent<CharacterProLoader>().skill_4_TimeToLive + 2;

                int countSword=skill_4.transform.GetChild(2).childCount;
                for (int i=0;i< countSword;i++)
                {
                    skill_4.transform.GetChild(2).GetChild(i).GetComponent<TimeToLive>().time_ToLive= this_Player.GetComponent<CharacterProLoader>().skill_4_TimeToLive;
                    skill_4.transform.GetChild(2).GetChild(i).GetComponent<Skill_Effect_Brain>().this_EffectDamage = this_Player.GetComponent<CharacterProLoader>().skill_4_deal_DamagePerSword;
                }
                skill_4.transform.Translate(0, this_CastingPoint_Height, 0);
                skill_4.transform.parent = this_Player_Bottom.transform;
                Skill_4_Casting = false;
            }

            if (calling_MeteorRain >= wait_for_MeteorRain && isCreated==false)
            {
                skill_3_Casting();
                this_Cammera.GetComponent<CameraShakeManager>().duration += 2;
                isCreated = true;
            }
        }
    }


    //Script Supporting:
    private void skill_3_Casting()
    {
        var meteor_skill_3 = Instantiate(object_Skills[1], this_Player_Bottom.transform.position, this_Player_Bottom.transform.rotation);
        meteor_skill_3.transform.GetChild(5).GetComponent<AOE_BurningDamage>().damage_Burning=this_Player.GetComponent<CharacterProLoader>().skill_3_deal_DamagePerSecond;
        Destroy(meteor_skill_3, duration_MeteorRain);
        star_Counting_Skill_3 = false;
    }

}



