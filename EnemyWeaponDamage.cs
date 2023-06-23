using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{
    [SerializeField] GameObject this_Enemy_Perfab;
    [SerializeField] float this_WeaponDamage;
    float nextDealDamage = 0;
    [SerializeField]  float delayDealDamage=0;

    private void Update()
    {/*
        if(this_Enemy_Perfab.GetComponent<HealthController>().isDie)
        {
            Destroy(this.gameObject);
        }
        */
    }

    private void OnTriggerEnter(Collider Object)
    {
        if(Time.time>=nextDealDamage)
        {
            if (Object.gameObject.layer == 3)
            {
                int newDamage = (int)Random.Range(this_WeaponDamage - 5f, this_WeaponDamage + 5f);
                Object.GetComponent<HealthController>().TakeDamge((int)newDamage);
                nextDealDamage=Time.time+delayDealDamage;
            }
        }
    }


}
