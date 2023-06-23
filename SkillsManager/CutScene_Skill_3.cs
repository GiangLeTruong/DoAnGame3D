using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene_Skill_3 : MonoBehaviour
{
    Transform point;
    [SerializeField] float timeToPlay_Skill_3;
    [SerializeField] GameObject skill_3_Portal;
    [SerializeField] GameObject skill_3_Meteor;
    [SerializeField] float duration_MeteorRain;
    //logic:
    bool isRain=false;
    bool isPortal = false;




    // Start is called before the first frame update
    void Start()
    {
        point=this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>timeToPlay_Skill_3)
        {
            if(isPortal == false)
            {
                create_Portal();
            }
        }
    }

    void create_Portal()
    {
        var portal_skill_3 = Instantiate(skill_3_Portal, point.transform.position, point.transform.rotation);
        if(isRain == false)
        {
            Invoke("create_Rain_Meteor", 1.5f);
        }
        Destroy(portal_skill_3, duration_MeteorRain+2f);
        isPortal = true;
    }
    void create_Rain_Meteor()
    {
        var meteor_skill_3 = Instantiate(skill_3_Meteor, point.transform.position, point.transform.rotation);
        Destroy(meteor_skill_3, duration_MeteorRain);
        isRain = true;
    }






}
