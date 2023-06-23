using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkCircle : MonoBehaviour
{
    GameObject this_Sword;
    [SerializeField] GameObject player_CentralPoint;
    [SerializeField] float flying_Speed=0f;

    //Set Time:
    [SerializeField] float flying_Duration = 0f;
    //Set Release Dagger:
    bool isRelease = false;
    //
    [SerializeField] GameObject Audio_Release;


    // Start is called before the first frame update
    void Start()
    {
        this_Sword=this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        set_flyAround();
        if(isRelease)
        {
            set_Realease();
        }
        


    }

    void set_flyAround()
    {
        if(flying_Duration>0)
        {
            this_Sword.transform.RotateAround(player_CentralPoint.transform.position, Vector3.down, flying_Speed);
            flying_Duration-=Time.deltaTime;
            isRelease = false;
        }
        else
        {
            isRelease = true;
        }
    }
    void set_Realease()
    {
        this_Sword.transform.LookAt(player_CentralPoint.transform);
        this_Sword.transform.Rotate(0,180,0);
        this_Sword.GetComponent<Rigidbody>().AddRelativeForce(0,0,100);
        Audio_Release.SetActive(true);
    }

}
