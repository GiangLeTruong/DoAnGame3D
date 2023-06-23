using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheckSwamp : MonoBehaviour
{
    [SerializeField] GameObject this_Enemy_Perfab;
    GameObject this_Swamp_Point;
    float check_Time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        this_Swamp_Point = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(check_Time>=0&& this_Swamp_Point.transform.childCount == 0)
        {
            check_Time -= Time.deltaTime;
        }
        if(check_Time<=0)
        {
            check_Empty();
        }

    }
    
    void check_Empty()
    {
        if(this_Swamp_Point.transform.childCount==0)
        {
            swap_Creep();
            check_Time = 5f;
        }
        
    }
    void swap_Creep()
    {
        GameObject perfab = Instantiate(this_Enemy_Perfab, this_Swamp_Point.transform.position, this_Swamp_Point.transform.rotation);
        perfab.transform.parent = this_Swamp_Point.transform;
    }
    
}
