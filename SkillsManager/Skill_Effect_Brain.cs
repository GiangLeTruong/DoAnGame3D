using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effect_Brain : MonoBehaviour
{
    public float this_EffectDamage=0f;
    [SerializeField] bool isDestroyWhenAttach=true;
    private void OnTriggerEnter(Collider Object)
    {
        if (Object.gameObject.layer == 7)
        {
            int newDamage = (int)Random.Range(this_EffectDamage - 0f, this_EffectDamage + 0f);
            if(Object.GetComponent<HealthController>())
            {
                Object.GetComponent<HealthController>().TakeDamge((int)newDamage);
            }    
            if(isDestroyWhenAttach)
            {
                Destroy(this.gameObject);
            }
            
        }
        else if (Object.gameObject.layer == 8)
        {
            if (isDestroyWhenAttach)
            {
                Destroy(this.gameObject);
            }
        }



    }


}
