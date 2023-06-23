using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class PlayerMovementAndAttack : MonoBehaviour
{
    //Player and Camera:
    private Rigidbody character_Rigidbody;
    public Transform character_Camera;
    [SerializeField] GameObject skill_CastingPoint;

    //Start game waiting:
    float waitStarting = 1f;
    float countStartingTime = 0f;

    //Aiming:
    float lookHorizontal;
    public float lookVertical;
    public float rotateSpeed = 8f;



    //Movement:
    float speed = 1f;
    float moveSide;
    float moveTrans;
    bool isMove = false;
    bool isRun = false;
    float jumpCasting;
    float jumpHeight = 40000f;
    float time_jumpUpCasting = 0f;
    float time_nextJumpUp = 0.1f;

    //Attack Meele:
    float normalATKCasting;
    public float attackRateMeele = 1;//This means how many attack per 1sec.
    float time_nextAttackMeele = 0;
    public Transform attackPoint;
    private float attackRange=1f;
    public LayerMask enemy_Layers;
    public float attackDamage=10;


    //Attack Rate:
    float drawArrowCasting;
    bool isAiming = false;
    public float attackRateRanger = 1;//This means how many attack per 1sec.
    float time_nextAttackRange = 0;


    //Skill Casting:
    float skillCasting;
    string activeSkill = "None";
    float time_cast_Skill1;
    float time_cast_Skill2;
    float time_cast_Skill3;
    float time_Casting = 0f;
    float time_nextCasting = 0f;
    //Skill Casting logic:
    public bool isCasting_Skill_1 = false;
    public bool isCasting_Skill_3 = false;
    public bool isCasting_Skill_4 = false;
    public float skill_Timing;
    //Skill Indicator:
    [SerializeField] GameObject indicator_Skill_1;
    [SerializeField] GameObject indicator_Skill_3;
    [SerializeField] GameObject indicator_Skill_4;




    //Set Drink:
    float drinkCasting;
    float time_drinkPosCasting = 0f;
    float time_nextDrinkPos = 0f;
    bool isDone = false;

    //Animation Play:
    private Animator character_Animator;

    //Audio:
    public AudioSource AudioConsumed_Gold;
    public AudioSource AudioConsumed_Blood;
    public AudioSource AudioConsumed_Mana;
    public AudioSource AudioDrink_Fluid;
    public AudioSource AudioEmptyItem;
    public AudioSource AudioSwordSwing;

    //private bool isMeele = false;
    //private bool isRanger = false;
    //// Start is called before the first frame update
    private void Start()
    {
        lookHorizontal = lookVertical = 0;

        character_Rigidbody = this.GetComponent<Rigidbody>();
        character_Animator = this.GetComponent<Animator>();
        if (character_Rigidbody.tag == "Warrior")
        {
            time_cast_Skill1 = 3.5f;
            time_cast_Skill2 = 2.9f;
            time_cast_Skill3 = 2.35f;
            time_jumpUpCasting = 0.95f;
            time_drinkPosCasting = 3.5f / 2;
        }

        if (character_Rigidbody.tag == "Berserker")
        {
            time_cast_Skill1 = 4.65f;
            time_cast_Skill2 = 2.82f;
            time_cast_Skill3 = 2.15f;
        }
        /*
        if (character_Rigidbody.tag == "Marksman")
        {
            time_cast_Skill1 = 3.5f;
            time_cast_Skill2 = 2.9f;
            time_cast_Skill3 = 2.35f;
        }
        */
    }
    //// Update is called once per frame
    void Update()
        
    {
        skill_Timing = time_nextCasting;
        set_Indicator();
        //Check Attack Rate:
        if (character_Rigidbody.tag != "Marksman")
        {
            character_Animator.SetFloat("AttackRate", attackRateMeele);
        }
        else
        {
            character_Animator.SetFloat("AttackRate", attackRateRanger);
        }
        
        countStartingTime += Time.deltaTime;
        if (countStartingTime > waitStarting)
        {
            if (Time.time >= time_nextCasting && Time.time >= time_nextJumpUp && Time.time >= time_nextDrinkPos)
            {
                if (this.GetComponent<HealthController>().isDie == false)
                {
                    Looking();
                } 
            }
        }

        //Reset Drinking:
        if(Time.time >= time_nextDrinkPos)
        {
            isDone = false;
        }




        //Set skill by button:
        AckActiveSkill();
        if(this.GetComponent<HealthController>().isDie==false)
        {
            if (character_Rigidbody.tag == "Marksman")
            {
                MovementRange();
            }
            else
            {
                MovementMeele();
            }
        }
        else
        {
            this.GetComponent<RigBuilder>().enabled = false;
        }
    }
    //void AckTypeOfCharacter()
    //{
    //    if (This_Character.tag == "Warrior")
    //    {
    //        isMeele = true;
    //        isRanger = false;
    //    }
    //    if (This_Character.tag == "Berserker")
    //    {
    //        isMeele = true;
    //        isRanger = false;
    //    }
    //    if (This_Character.tag == "Marksman")
    //    {
    //        isMeele = false;
    //        isRanger = true;
    //    }
    //}
    void AckActiveSkill()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            activeSkill = "Skill1";
            time_Casting = time_cast_Skill1;
            isCasting_Skill_1 = true;
            isCasting_Skill_3 = false;
            isCasting_Skill_4 = false;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            activeSkill = "Skill3";
            time_Casting = time_cast_Skill2;
            isCasting_Skill_1 = false;
            isCasting_Skill_3 = true;
            isCasting_Skill_4 = false;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            activeSkill = "Skill4";
            time_Casting = time_cast_Skill3;
            isCasting_Skill_1 = false;
            isCasting_Skill_3 = false;
            isCasting_Skill_4 = true;
        }
    }
    private void Looking()
    {
        //Set for Horizontal:
        if (lookHorizontal >= 2 && !isMove)
        {
            character_Animator.SetBool("isTurnRight", true);
        }
        else
        {
            character_Animator.SetBool("isTurnRight", false);
        }
        if (lookHorizontal <= -2 && !isMove)
        {
            character_Animator.SetBool("isTurnLeft", true);
        }
        else
        {
            character_Animator.SetBool("isTurnLeft", false);
        }
        character_Rigidbody.transform.Rotate(0, lookHorizontal * rotateSpeed * Time.deltaTime, 0);
        //Set for Vertical:
        if(character_Rigidbody.tag == "Marksman")
        {
            if (isAiming)
            {
                this.GetComponent<RigBuilder>().enabled = true;
            }
            else
            {
                this.GetComponent<RigBuilder>().enabled = false;
            }
        }
        else
        {
            this.GetComponent<RigBuilder>().enabled = true; 
        }
        

    }

    private void MovementMeele()
    {
        //Walk:
        if (moveSide != 0f || moveTrans != 0f)
        {
            if (Time.time >= time_nextCasting && Time.time >= time_nextJumpUp && Time.time >= time_nextDrinkPos)
            {
                isMove = true;
                character_Animator.SetBool("isMove", isMove);
            }
            else
            {
                isMove = false;
                character_Animator.SetBool("isMove", isMove);
            }
            //if(Time.time >= time_jumpUpnext)
            //{
            //    isMove = true;
            //    character_Animator.SetBool("isMove", isMove);
            //}
            //else
            //{
            //    isMove = false;
            //    character_Animator.SetBool("isMove", isMove);
            //}
        }
        else
        {
            isMove = false;
            character_Animator.SetBool("isMove", isMove);
        }
        //character_Rigidbody.transform.position = Vector3.Lerp(new Vector3(character_Rigidbody.transform.position.x, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z), new Vector3(character_Rigidbody.transform.position.x + moveSide * speed, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z + moveTrans), Time.deltaTime * speed);
        //Run:
        if (isMove)
        {
            //character_Rigidbody.transform.position = Vector3.Slerp(new Vector3(character_Rigidbody.transform.position.x, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z), new Vector3(character_Rigidbody.transform.position.x + moveSide, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z + moveTrans), Time.deltaTime * speed);
            character_Rigidbody.transform.Translate(moveSide * Time.deltaTime * speed, 0, moveTrans * Time.deltaTime * speed);
            character_Animator.SetFloat("MoveX", moveSide);
            character_Animator.SetFloat("MoveY", moveTrans);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRun = true;
                character_Animator.SetBool("isRun", isRun);
                speed = 6f;

            }
            else
            {
                isRun = false;
                character_Animator.SetBool("isRun", isRun);
                speed = 1f;
            }
            if (jumpCasting == 1 && Time.time >= time_nextDrinkPos)
            {

                if (moveTrans > 0 && Time.time >= time_nextJumpUp)
                {
                    float addforce = Time.deltaTime * jumpHeight;
                    if (addforce >= 250f || addforce <= 180f)
                    {
                        addforce = 220f;
                    }
                    character_Animator.Play("JumpRun");
                    character_Rigidbody.AddRelativeForce(0, addforce, addforce / 2f);
                    //character_Rigidbody.AddRelativeForce(Vector3.up * addforce);
                    //character_Rigidbody.AddRelativeForce(Vector3.forward * addforce / 2.5f);
                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
                if (moveTrans < 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }

                if (moveSide > 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
                if (moveSide < 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
            }
            if (normalATKCasting == 1 && Time.time >= time_nextAttackMeele)
            {
                time_nextAttackMeele = Time.time + 1f / attackRateMeele;
                character_Animator.Play("NormalAttack");
                AudioSwordSwing.Play();
                Invoke("dealDamage", (1 / attackRateMeele) * 0.6f);
            }
            if (this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level > 0)
            {
                skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_2_Casting = true;
            }
            if (skillCasting == 1 && Time.time >= time_nextCasting && Time.time >= time_nextDrinkPos)
            {
                if (activeSkill == "Skill1")
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level > 0 && this.GetComponent<ManaController>().currenMana >= 15)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(15);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_1_Casting = 1;
                    }
                }
                if (activeSkill == "Skill3")
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level > 0 && this.GetComponent<ManaController>().currenMana >= 25)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(25);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_3_Casting = true;
                    }
                }
                if (activeSkill == "Skill4")
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level > 0 && this.GetComponent<ManaController>().currenMana >= 40)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(40);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_4_Casting = true;
                    }
                }
            }
            if (drinkCasting == 1 && Time.time >= time_nextJumpUp && Time.time >= time_nextCasting)
            {

                if (this.GetComponent<UISystem>().isOnBood && this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition > 0)
                {
                    time_nextDrinkPos = time_drinkPosCasting + Time.time;
                    character_Animator.Play("Drink");
                    //Play Audio Drink:
                    AudioDrink_Fluid.PlayDelayed(0.6f);
                    //Set do 1 time:
                    if (isDone == false)
                    {
                        this.GetComponent<HealthController>().currenHealth += 50;
                        this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition -= 1;
                        isDone = true;
                    }


                }
                else
                {
                    if(this.GetComponent<UISystem>().isOnBood&& this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition <= 0)
                    {
                        //Play Audio cant Drink:
                        AudioEmptyItem.Play();
                    }
                }
                if (this.GetComponent<UISystem>().isOnMana && this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition > 0)
                {
                    time_nextDrinkPos = time_drinkPosCasting + Time.time;
                    character_Animator.Play("Drink");
                    //Play Audio Drink:
                    AudioDrink_Fluid.PlayDelayed(0.6f);
                    //Set do 1 time:
                    if (isDone == false)
                    {
                        this.GetComponent<ManaController>().currenMana += 25;
                        this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition -= 1;
                        isDone = true;
                    }

                }
                else
                {
                    if (this.GetComponent<UISystem>().isOnMana&& this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition <= 0)
                    {
                        //Play Audio cant Drink:
                        AudioEmptyItem.Play();
                    }
                }
            }
        }
        else
        {
            isRun = false;
            character_Animator.SetBool("isRun", isRun);
            speed = 1f;
            if (jumpCasting == 1 && Time.time >= time_nextDrinkPos)
            {
                if (Time.time >= time_nextJumpUp)
                {
                    float addforce = Time.deltaTime * jumpHeight;
                    if (addforce >= 250f || addforce <= 180f)
                    {
                        addforce = 220f;
                    }
                    character_Animator.Play("Jump");
                    character_Rigidbody.AddRelativeForce(Vector3.up * addforce);
                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
            }

            if (normalATKCasting == 1 && Time.time >= time_nextAttackMeele)
            {
                time_nextAttackMeele = Time.time + 1f / attackRateMeele;
                character_Animator.Play("NormalAttack");
                AudioSwordSwing.Play();
                Invoke("dealDamage", (1/attackRateMeele) * 0.6f);
                
            }
            if (this.GetComponent<CharacterProLoader>().char_Current_Skill_2_Level > 0)
            {
                skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_2_Casting = true;
            }
            if (skillCasting == 1 && Time.time >= time_nextCasting && Time.time >= time_nextDrinkPos)
            {
                if(activeSkill== "Skill1")
                {
                    if(this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level>0&& this.GetComponent<ManaController>().currenMana>=15)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(15);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_1_Casting = 1;
                    }
                }
                if (activeSkill == "Skill3")
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level > 0 && this.GetComponent<ManaController>().currenMana >= 25)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(25);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_3_Casting = true;
                    }
                }
                if (activeSkill == "Skill4")
                {
                    if (this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level > 0 && this.GetComponent<ManaController>().currenMana >= 40)
                    {
                        this.GetComponent<RigBuilder>().enabled = false;
                        time_nextCasting = time_Casting + Time.time;
                        this.GetComponent<ManaController>().LostMana(40);
                        character_Animator.Play(activeSkill);
                        skill_CastingPoint.GetComponent<Player_Skills_Manager>().Skill_4_Casting = true;
                    }
                }
            }
            if (drinkCasting == 1 && Time.time >= time_nextJumpUp && Time.time >= time_nextCasting)
            {
                
                if(this.GetComponent<UISystem>().isOnBood&&this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition>0)
                {
                    time_nextDrinkPos = time_drinkPosCasting + Time.time;
                    character_Animator.Play("Drink");
                    //Play Audio Drink:
                    AudioDrink_Fluid.PlayDelayed(0.6f);
                    //Set do 1 time:
                    if(isDone== false)
                    {
                        this.GetComponent<HealthController>().currenHealth += 50;
                        this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition -= 1;
                        isDone = true;
                    }
                    

                }
                if(this.GetComponent<UISystem>().isOnBood && this.GetComponent<CharacterProLoader>().char_Current_Blood_Poition <= 0&& isDone == false)
                {
                    //Play Audio cant Drink:
                    AudioEmptyItem.Play();
                }
                if (this.GetComponent<UISystem>().isOnMana && this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition > 0)
                {
                    time_nextDrinkPos = time_drinkPosCasting + Time.time;
                    character_Animator.Play("Drink");
                    //Play Audio Drink:
                    AudioDrink_Fluid.PlayDelayed(0.6f);
                    //Set do 1 time:
                    if (isDone == false)
                    {
                        this.GetComponent<ManaController>().currenMana += 25;
                        this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition -= 1;
                        isDone = true;
                    }

                }
                if (this.GetComponent<UISystem>().isOnMana && this.GetComponent<CharacterProLoader>().char_Current_Mana_Poition <= 0&& isDone == false)
                {
                    //Play Audio cant Drink:
                    AudioEmptyItem.Play();
                }
            }
        }
    }
    private void MovementRange()
    {
        //Walk:
        if (moveSide != 0f || moveTrans != 0f)
        {
            if (Time.time >= time_nextCasting && Time.time >= time_nextJumpUp && Time.time >= time_nextDrinkPos && isAiming == false)
            {
                isMove = true;
                character_Animator.SetBool("isMove", isMove);
            }
            else
            {
                isMove = false;
                character_Animator.SetBool("isMove", isMove);
            }
            //if(Time.time >= time_jumpUpnext)
            //{
            //    isMove = true;
            //    character_Animator.SetBool("isMove", isMove);
            //}
            //else
            //{
            //    isMove = false;
            //    character_Animator.SetBool("isMove", isMove);
            //}
        }
        else
        {
            isMove = false;
            character_Animator.SetBool("isMove", isMove);
        }
        //character_Rigidbody.transform.position = Vector3.Lerp(new Vector3(character_Rigidbody.transform.position.x, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z), new Vector3(character_Rigidbody.transform.position.x + moveSide * speed, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z + moveTrans), Time.deltaTime * speed);
        //Run:
        if (isMove)
        {
            //character_Rigidbody.transform.position = Vector3.Slerp(new Vector3(character_Rigidbody.transform.position.x, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z), new Vector3(character_Rigidbody.transform.position.x + moveSide, character_Rigidbody.transform.position.y, character_Rigidbody.transform.position.z + moveTrans), Time.deltaTime * speed);
            character_Rigidbody.transform.Translate(moveSide * Time.deltaTime * speed, 0, moveTrans * Time.deltaTime * speed);
            character_Animator.SetFloat("MoveX", moveSide);
            character_Animator.SetFloat("MoveY", moveTrans);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isRun = true;
                character_Animator.SetBool("isRun", isRun);
                speed = 3f;

            }
            else
            {
                isRun = false;
                character_Animator.SetBool("isRun", isRun);
                speed = 1f;
            }
            if (jumpCasting == 1 && Time.time >= time_nextDrinkPos)
            {

                if (moveTrans > 0 && Time.time >= time_nextJumpUp)
                {
                    float addforce = Time.deltaTime * jumpHeight;
                    if (addforce >= 250f || addforce <= 180f)
                    {
                        addforce = 220f;
                    }
                    character_Animator.Play("JumpRun");
                    character_Rigidbody.AddRelativeForce(0, addforce, addforce / 2f);
                    //character_Rigidbody.AddRelativeForce(Vector3.up * addforce);
                    //character_Rigidbody.AddRelativeForce(Vector3.forward * addforce / 2.5f);
                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
                if (moveTrans < 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }

                if (moveSide > 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
                if (moveSide < 0 && Time.time >= time_nextJumpUp)
                {

                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
            }
            if (drawArrowCasting == 1 && Time.time >= time_nextAttackRange)
            {
                time_nextAttackRange = Time.time + 1.00f / attackRateRanger;
                character_Animator.SetBool("isRelease", false);
                character_Animator.SetBool("isDrawing", true);
                isAiming = true;
            }
            if (drawArrowCasting == 0 && isAiming == true)
            {
                character_Animator.SetBool("isRelease", true);
                character_Animator.SetBool("isDrawing", false);
                isAiming = false;
            }
            if (skillCasting == 1 && Time.time >= time_nextDrinkPos)
            {
                time_nextCasting = time_Casting + Time.time;
                character_Animator.Play(activeSkill);
            }
            if (drinkCasting == 1)
            {
                time_nextDrinkPos = time_drinkPosCasting + Time.time;
                character_Animator.Play("Drink");
            }
        }
        else
        {
            isRun = false;
            character_Animator.SetBool("isRun", isRun);
            speed = 1f;
            if (jumpCasting == 1 && Time.time >= time_nextDrinkPos)
            {
                if (Time.time >= time_nextJumpUp)
                {
                    float addforce = Time.deltaTime * jumpHeight;
                    if (addforce >= 250f || addforce <= 180f)
                    {
                        addforce = 220f;
                    }
                    character_Animator.Play("Jump");
                    character_Rigidbody.AddRelativeForce(Vector3.up * addforce);
                    time_nextJumpUp = time_jumpUpCasting + Time.time;
                }
            }

            if (drawArrowCasting == 1 && Time.time >= time_nextAttackRange)
            {
                time_nextAttackRange = Time.time + 1.00f / attackRateRanger;
                character_Animator.SetBool("isRelease", false);
                character_Animator.SetBool("isDrawing", true);
                isAiming = true;
            }
            if (drawArrowCasting == 0 && isAiming == true)
            {
                character_Animator.SetBool("isRelease", true);
                character_Animator.SetBool("isDrawing", false);
                isAiming = false;
            }
            if (skillCasting == 1 && Time.time >= time_nextDrinkPos)
            {
                time_nextCasting = time_Casting + Time.time;
                character_Animator.Play(activeSkill);
            }
            if (drinkCasting == 1 && Time.time >= time_nextJumpUp && Time.time >= time_nextCasting)
            {
                time_nextDrinkPos = time_drinkPosCasting + Time.time;
                character_Animator.Play("Drink");
            }

        }

    }
    
    private void dealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemy_Layers);
        foreach (Collider hit in hitEnemies)
        {
            int newDamage = (int)Random.Range(attackDamage - 5f, attackDamage + 5f);
            if(hit.GetComponent<HealthController>())
            {
                hit.GetComponent<HealthController>().TakeDamge((int)newDamage);
            }
        }
    }




    //---IF(isMeele)

    public void SetMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        moveSide = value.x;
        moveTrans = value.y;
    }

    //Jump(Space):
    public void SetLook(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        lookHorizontal = value.x;
        lookVertical = value.y;
    }


    public void SetJump(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        jumpCasting = value;

    }

    // Normal Attack (Left Click):
    public void SetAttackMeele(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        normalATKCasting = value;
    }
    public void SetAttackRange(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        drawArrowCasting = value;
    }





    // Skill-Casting (Right Click):
    public void SetCasting(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        skillCasting = value;
    }
    // Changle Poision->Mana/Back  (Tab):


    // Drink Poision (Q):
    public void SetDrink(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<float>();
        drinkCasting = value;
    }

    //---IF(isRanger)
    //Move Aim (WASD):




    //Jump When Idle (Space && isMoving=false):


    //Jump When Move(Space && isMoving=true):


    // Normal Attack (Left Click->Draw-Aim-Release):


    void set_Indicator()
    {
        if(this.GetComponent<CharacterProLoader>().char_Current_Skill_1_Level > 0&& isCasting_Skill_1)
        {
            indicator_Skill_1.SetActive(true);
            indicator_Skill_3.SetActive(false);
            indicator_Skill_4.SetActive(false);
        }
        if(this.GetComponent<CharacterProLoader>().char_Current_Skill_3_Level > 0 && isCasting_Skill_3)
        {
            indicator_Skill_1.SetActive(false);
            indicator_Skill_3.SetActive(true);
            indicator_Skill_4.SetActive(false);
        }
        if(this.GetComponent<CharacterProLoader>().char_Current_Skill_4_Level > 0 && isCasting_Skill_4)
        {
            indicator_Skill_1.SetActive(false);
            indicator_Skill_3.SetActive(false);
            indicator_Skill_4.SetActive(true);
        }
    }




    // Check Skill-Casting:
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
