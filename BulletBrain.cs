using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrain : MonoBehaviour
{
    [SerializeField] Rigidbody this_Bullet;
    [SerializeField] float this_BulletDamage;
    [SerializeField] float this_BulletSpeed;
    //[SerializeField] ParticleSystem this_BulletBreak;
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        this_Bullet.AddRelativeForce(new Vector3(0, 0, 1 * this_BulletSpeed * Time.deltaTime), ForceMode.Force);
    }
    private void OnTriggerEnter(Collider Object)
    {
      if(Object.gameObject.layer==3)
      {
            int newDamage = (int)Random.Range(this_BulletDamage - 5f, this_BulletDamage + 5f);
            Object.GetComponent<HealthController>().TakeDamge((int)newDamage);
            Destroy(this.gameObject);
      }
      else if(Object.gameObject.layer == 8)
      {
            Destroy(this.gameObject);
      }



    }

}
