using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.AI;

public class EnemyBrain : MonoBehaviour
{
    //Object:
    private GameObject Player;
    private GameObject this_Enemy;
    public Transform this_Enemy_Default;
    private Animator this_Animator;

    //Navmesh:
    private NavMeshAgent this_NavMeshAgent;

    //Set Exp For Player:
    private bool isAddedExp=false;

    //Enemy Movement:
    bool canMove = false;
    public float moveSpeed = 0.7f;
    //Enemy Attack:
    bool canAttack = false;
    public bool canShoot = false; // For ranger enemy.
    public float attackRange = 0;
    [SerializeField] float attackDamage;
    [SerializeField] Transform attackPoint;
    public LayerMask player_Layers;
    [SerializeField] float attackRate=0f;
    float nextAttack = 0f;

    //Count number of attack:
    bool isFirstAttack = true;
    [SerializeField] AudioSource audio_Boss_Skill_1;
    [SerializeField] AudioSource audio_Boss_Skill_2;

    //Enemy Arlert:
    public float senseRange = 0;
    bool canHunt = false;

    /*
    //Enemy Animator Act:
    public string anim_Attack;
    public string anim_Move;
    public string anim_Damaged;
    public string anim_Death;
    */


    //Enemy turn back default position:
    float time_Hunting = 10;
    float time_HuntingCount = 0;
    bool mustTurnBack = false;

    //Boss Brain:
    int count_Boss_Attack=0;
    bool isCast_Skill_1 = false;
    bool isCast_Skill_2 = false;
    [SerializeField] Transform swamp_Point;
    [SerializeField] GameObject perfab_Skill_1;
    [SerializeField] GameObject perfab_Skill_2;

    [SerializeField] ParticleSystem indicator_Boss_Skill_2;


    private void Awake()
    {
        this_NavMeshAgent=GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this_Enemy = this.GameObject();
        this_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Find_Player_Class();
        if (Player != null)
        {
            if(this.GetComponent<HealthController>().isDie==false)
            {
            if (mustTurnBack == false)
            {
                ack_Player();
                    if(this.transform.tag=="Boss")
                    {
                        set_Attack_Boss();
                    }
                    else
                    {
                        set_Attack();
                    }
                set_Move();
                set_Hunt();
                if (canHunt)
                {
                    if (canMove)
                    {
                        moving_ThisEnemy();
                        time_HuntingCount += Time.deltaTime;
                    }
                    else
                    {
                        stop_moving_ThisEnemy();
                    }
                }
                else
                {
                    set_Return();
                }
            }
            else
            {
                set_Return();
            }
            }
            else
            {
                canHunt = false;
                canMove = false;
                canAttack = false;
                if(isAddedExp==false)
                {
                    set_AddExpForPlayer();
                }
                stop_moving_ThisEnemy();
            }
        }
    }
        private void Find_Player_Class()
    {

        if (GameObject.FindGameObjectWithTag("Warrior") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Warrior");
        }
        else if (GameObject.FindGameObjectWithTag("Berserker") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Berserker");
        }
        else if (GameObject.FindGameObjectWithTag("Marksman") != null)
        {
            Player = GameObject.FindGameObjectWithTag("Marksman");
        }
        else Player = null;
        
    }
    void moving_ThisEnemy()
    {
        //this_Enemy.transform.position = Vector3.Lerp(new Vector3(this_Enemy.transform.position.x, this_Enemy.transform.position.y, this_Enemy.transform.position.z), new Vector3(Player.transform.position.x, this_Enemy.transform.position.y, Player.transform.position.z), Time.deltaTime * moveSpeed);
        this_NavMeshAgent.destination = Player.transform.position;
    }
    void stop_moving_ThisEnemy()
    {
        //this_Enemy.transform.position = Vector3.Lerp(new Vector3(this_Enemy.transform.position.x, this_Enemy.transform.position.y, this_Enemy.transform.position.z), new Vector3(Player.transform.position.x, this_Enemy.transform.position.y, Player.transform.position.z), Time.deltaTime * moveSpeed);
        this_NavMeshAgent.destination = this_Enemy.transform.position;
    }

    void ack_Player()
    {
        float distance = Vector3.Distance(this_Enemy.transform.position, Player.transform.position);
        if (distance > senseRange)
        {
            canHunt = false;
            canMove = false;
            canAttack = false;

        }
        else
        {
            canHunt = true;
            
            if (distance > attackRange)
            {
                if (time_HuntingCount < time_Hunting)
                {
                    
                    canMove = true;
                    //this_Enemy.transform.LookAt(Player.transform);
                    canAttack = false;
                   
                }
                else
                {
                    mustTurnBack = true;
                }
            }
            else
            {
                canMove = false;
                canAttack = true;
               
            }
            
        }


    }

    void set_Hunt()
    {
        this_Animator.SetBool("canHunt", canHunt);

        if (canHunt == true)
        {
            this_Enemy.transform.LookAt(Player.transform);
        }
    }
        void set_Attack()
    {
        this_Animator.SetBool("canAttack", canAttack);
        if(this_Enemy.transform.tag== "EnemyRanger")
        {
            if (canAttack)
            {
                if (Time.time >= nextAttack)
                {
                    canShoot = true;
                    nextAttack = Time.time + attackRate;
                }
                else
                {
                    canShoot = false;
                }
            }
            else
            {
                canShoot = false;
                nextAttack = -1;
            }
        }
        else
        {
            if(canAttack)
            {
                if(Time.time >= nextAttack)
                {
                    if (isFirstAttack)
                    {
                        isFirstAttack = false;
                    }
                    else
                    {
                        //dealDamageMeele();
                    }
                    nextAttack = Time.time + attackRate;
                }
            }
            else
            {
                nextAttack = -1;
                isFirstAttack = true;
            }
        }
        
    }


    void set_Attack_Boss()
    {
        //Set Casting Skill:
        this_Animator.SetInteger("countAttack", count_Boss_Attack);
        this_Animator.SetBool("canAttack", canAttack);
        if(count_Boss_Attack>3&& count_Boss_Attack < 5)
        {
            audio_Boss_Skill_1.Play();
            Invoke("casting_Boss_Skill_1", 3f);
            isCast_Skill_2 = false;
        }
        if(count_Boss_Attack > 10)
        {
            audio_Boss_Skill_2.PlayDelayed(0.3f);
            indicator_Boss_Skill_2.Play();
            audio_Boss_Skill_2.Play();
            Invoke("casting_Boss_Skill_2", 2f);
            count_Boss_Attack = 0;
            isCast_Skill_1 = false;
        }
            if (canAttack)
            {
                if (Time.time >= nextAttack)
                {
                    count_Boss_Attack += 1;
                    if (isFirstAttack)
                    {
                        isFirstAttack = false;
                    }
                    else
                    {
                        //dealDamageMeele();
                    }
                    nextAttack = Time.time + attackRate;
                }
            }
            else
            {
                nextAttack = -1;
                isFirstAttack = true;
            }
    }


    void set_Move()
    {
            this_Animator.SetBool("canMove", canMove);
    }

    private void set_Return()
    {
        float distance = Vector3.Distance(this_Enemy.transform.position, this_Enemy_Default.position);
        count_Boss_Attack = 0;
        if (distance>1)
        {
            canMove = true;
            set_Move();
            //this_Enemy.transform.position = Vector3.Lerp(new Vector3(this_Enemy.transform.position.x, this_Enemy.transform.position.y, this_Enemy.transform.position.z), new Vector3(this_Enemy_Default.position.x, this_Enemy_Default.position.y, this_Enemy_Default.position.z), Time.deltaTime * moveSpeed);
            this_NavMeshAgent.destination = this_Enemy_Default.position;
            //this_Enemy.transform.LookAt(this_Enemy_Default);
        }
        else
        {
            this_NavMeshAgent.destination = this_Enemy.transform.position;
            canMove = false;
            time_HuntingCount = 0;
            mustTurnBack = false;
        }
    }

    private void dealDamageMeele()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, player_Layers);
        foreach (Collider hit in hitEnemies)
        {
            int newDamage = (int)Random.Range(attackDamage - 5f, attackDamage + 5f);
            hit.GetComponent<HealthController>().TakeDamge((int)newDamage);
        }
    }
    void set_AddExpForPlayer()
    {
        if(this_Enemy.GetComponent<HealthController>().isDie)
        {
            int expIncrease = Random.Range(this_Enemy.GetComponent<HealthController>().maxHealth-10, this_Enemy.GetComponent<HealthController>().maxHealth + 10);
            Player.GetComponent<CharacterProLoader>().char_Current_Exp += expIncrease;
            isAddedExp = true;
        }
    }

    void casting_Boss_Skill_1()
    {
        if(isCast_Skill_1 == false)
        {
            var skill_1 = Instantiate(perfab_Skill_1, new Vector3(swamp_Point.position.x, swamp_Point.position.y + 0.5f, swamp_Point.position.z), swamp_Point.rotation);
            skill_1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * 10000);
            skill_1.GetComponent<AudioSource>().PlayDelayed(0.5f);
            isCast_Skill_1 = true;
        }
        
    }
    void casting_Boss_Skill_2()
    {
        if (isCast_Skill_2 == false)
        {
            var skill_2 = Instantiate(perfab_Skill_2, new Vector3(swamp_Point.position.x, swamp_Point.position.y + 0.5f, swamp_Point.position.z), swamp_Point.rotation);
            isCast_Skill_2 = true;
        }

    }



    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange/5);
    }
    */
}
