using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE_BurningDamage : MonoBehaviour
{
    //Set Deal Damage:
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    public LayerMask enemy_Layers;
    
    //Set Damage:
    public int damage_Burning=0;

    //Timing:
    float nextDealDamage=0f;
    [SerializeField] float delayDealDamage = 0f;
    

    private void Update()
    {
        set_Burning();
    }
    private void set_Burning()
    {
        if (Time.time >= nextDealDamage)
        {
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemy_Layers);
            foreach (Collider enemy in hitEnemies)
            {
                int newDamage = (int)Random.Range(damage_Burning - 5f, damage_Burning + 5f);
                if (enemy.GetComponent<HealthController>())
                {
                    enemy.GetComponent<HealthController>().TakeDamge((int)newDamage);
                }
                
            }
            nextDealDamage = Time.time + delayDealDamage;
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}


