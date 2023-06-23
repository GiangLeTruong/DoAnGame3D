using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] float force_PullUp;
    [SerializeField] int drop_Times;
    GameObject this_DropPoint;
    [SerializeField] GameObject this_Enemy;
    [SerializeField] GameObject[] types_Of_Item=new GameObject[3];
    bool isCall = false;
    // Start is called before the first frame update
    void Start()
    {
        this_DropPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {   if(Input.GetKeyDown(KeyCode.P))
        {
            this_Enemy.GetComponent<HealthController>().TakeDamge(15);
        }
        
        if(this_Enemy.GetComponent<HealthController>().isDie==true&& isCall==false)
        {
            Invoke("set_DropItems",0.5f);
            isCall = true;
        }    
    }

    private void set_DropItems()
    {
        int drop_Time= Random.Range(1, drop_Times);
        
        for(int i =0; i< drop_Time; i++)
        {
            int type = Random.Range(0, 10);
            switch (type)
            {
                case 0:
                    var item_0 = Instantiate(types_Of_Item[0], new Vector3(this_DropPoint.transform.position.x, this_DropPoint.transform.position.y+4.5f, this_DropPoint.transform.position.z), this_DropPoint.transform.rotation);
                    item_0.GetComponent<Rigidbody>().AddForce(0, force_PullUp, 0);
                    break;
                case 1:
                    var item_1 = Instantiate(types_Of_Item[1], this_DropPoint.transform.position, this_DropPoint.transform.rotation);
                    item_1.GetComponent<Rigidbody>().AddForce(0, force_PullUp, 0);
                    break;
                
                default:
                    var item_2 = Instantiate(types_Of_Item[2], this_DropPoint.transform.position, this_DropPoint.transform.rotation);
                    item_2.GetComponent<Rigidbody>().AddForce(0, force_PullUp, 0);
                    break;
            }
               



               
           
            
        }
    }


}
