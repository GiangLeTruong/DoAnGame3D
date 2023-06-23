using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreatSword_Effect : MonoBehaviour
{

    private Transform this_Object_Transform;
    [SerializeField] float speed,strengh;
    bool isUp;
    float height_Max, height_Min;
    private void Start()
    {
        this_Object_Transform = this.transform;
        height_Max = this_Object_Transform.position.y + strengh;
        height_Min = this_Object_Transform.position.y - strengh;
    }
    void Update()
    {
        set_Floating();
    }

    void set_Floating()
    {
        
        if (this_Object_Transform.position.y>= height_Max)
        {
            //GettingDown:
            isUp=false;
        }
        if (this_Object_Transform.position.y <= height_Min)
        {
            //GettingUp:
            isUp = true;
        }
        if(isUp)
        {
            this_Object_Transform.Translate(0, 0, -1 * Time.deltaTime * speed);
        }
        else
        {
            this_Object_Transform.Translate(0, 0, +1 * Time.deltaTime * speed);
        }
        
    }

}
