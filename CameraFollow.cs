using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetPlayer;
    private Transform transformPlayer;
    private Transform this_Camera;

    //Tranlation:
    //private float lerpSpeed=10f;
    //Waiting Game Starting:
    float waitStarting = 1f;
    float countStartingTime = 0f;




    // Start is called before the first frame update
    void Start()
    {
        if(targetPlayer!=null)
        {
            transformPlayer = targetPlayer.GetComponent<Transform>();

            this_Camera = this.GetComponent<Transform>();
            //this_Camera.Rotate(28, 0, 0);
            this_Camera.Translate(0, 2.0f, -8f);
        }
    }
    private void Update()
    {
        if(targetPlayer != null)
        {
            countStartingTime += Time.deltaTime;
            if (countStartingTime > waitStarting)
            {
                LookingVertical();
            }

        }

    }

    private void LookingVertical()
    {
        
        if (this_Camera.transform.rotation.eulerAngles.x >= 20 && this_Camera.transform.rotation.eulerAngles.x <= 320)
        {
           if(this_Camera.transform.rotation.eulerAngles.x >= 20&& this_Camera.transform.rotation.eulerAngles.x <= 60)
           {
                this_Camera.transform.rotation = Quaternion.Euler(20, this_Camera.transform.rotation.eulerAngles.y, this_Camera.transform.rotation.eulerAngles.z);
           }
           if(this_Camera.transform.rotation.eulerAngles.x <= 320&& this_Camera.transform.rotation.eulerAngles.x >= 280)
           {
                this_Camera.transform.rotation = Quaternion.Euler(320, this_Camera.transform.rotation.eulerAngles.y, this_Camera.transform.rotation.eulerAngles.z);
           }
            this_Camera.transform.Rotate(targetPlayer.GetComponent<PlayerMovementAndAttack>().lookVertical * targetPlayer.GetComponent<PlayerMovementAndAttack>().rotateSpeed * Time.deltaTime*0.01f, 0, 0);

        }
        else
        {
            this_Camera.transform.Rotate(targetPlayer.GetComponent<PlayerMovementAndAttack>().lookVertical * targetPlayer.GetComponent<PlayerMovementAndAttack>().rotateSpeed * Time.deltaTime, 0, 0);
        }
        
        

    }
}
