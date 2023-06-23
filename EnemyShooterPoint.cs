using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterPoint : MonoBehaviour
{
    [SerializeField]  GameObject this_Enemy;
    Transform thisShooterPoint;
    [SerializeField] GameObject thisEnemyBulletPerfab;
    float next_Attack = 0f;
    // Start is called before the first frame update
    void Start()
    {
        thisShooterPoint=this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        set_Shooter();
    }

    private void set_Shooter()
    {
        if(this_Enemy)
        {
            if(this_Enemy.GetComponent<EnemyBrain>())
            {
                if (this_Enemy.GetComponent<EnemyBrain>().canShoot == true)
                {
                    var bullet = Instantiate(thisEnemyBulletPerfab, thisShooterPoint.position, thisShooterPoint.rotation);
                }
            }
            else
            {
                if(this_Enemy.tag=="CutSceneE")
                {
                    if(next_Attack<=Time.time)
                    {
                        var bullet = Instantiate(thisEnemyBulletPerfab, thisShooterPoint.position, thisShooterPoint.rotation);
                        next_Attack = Time.time + 2f;
                    }
                    
                }
            }
            
        }
        
    }

}
