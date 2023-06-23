using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Icon_Indicator : MonoBehaviour
{
    private Transform this_Object_Transform;
    [SerializeField] float speed, strengh;
    [SerializeField] bool isUp,isLeft;
    float far_Max, far_Min;
    float moving_Rate;
    private void Start()
    {
        this_Object_Transform = this.transform;
        far_Max= strengh;
        far_Min=-strengh;
    }
    void Update()
    {
      set_Floating_UpDown();
    }

    void set_Floating_UpDown()
    {
        if(isUp)
        {
            moving_Rate += Time.deltaTime * strengh;
            this_Object_Transform.Translate(0, 1 * Time.deltaTime * speed, 0);
        }
        else
        {
            moving_Rate -= Time.deltaTime * strengh;
            this_Object_Transform.Translate(0, -1 * Time.deltaTime * speed, 0);
        }

        if(moving_Rate>= far_Max)
        {
            isUp = false;
        }
       if(moving_Rate <= far_Min)
        {
            isUp = true;
        }
    }
}
