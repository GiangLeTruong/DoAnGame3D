using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBlowing : MonoBehaviour
{
    [SerializeField] ParticleSystem FX_Chest;
    float coutingBlow = 0;
    [SerializeField ]float attackDamage;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    public LayerMask player_Layers;
    bool isDealDamage = false;

    GameObject main_Camera;
    //Audio:
    public AudioSource Audio_Blowing;
    // Start is called before the first frame update
    void Start()
    {
        main_Camera = GameObject.FindGameObjectWithTag("MainCamera");
        attackRange = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<HealthController>().isDie==true)
        {
            coutingBlow += Time.deltaTime;
            if(coutingBlow>2)
            {
                if(isDealDamage == false)
                {
                    FX_Chest.Play();
                    Audio_Blowing.Play();
                    if(main_Camera)
                    {
                        if(main_Camera.GetComponent<CameraShakeManager>().duration<=0)
                        {
                            main_Camera.GetComponent<CameraShakeManager>().duration += 0.5f;
                        }
                        
                    }
                    dealDamage();
                    isDealDamage = true;
                }
                
            }
        }
    }
    private void dealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, player_Layers);
        foreach (Collider hit in hitEnemies)
        {
            int newDamage = (int)Random.Range(attackDamage - 5f, attackDamage + 5f);
            hit.GetComponent<HealthController>().TakeDamge((int)newDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
