using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
    [SerializeField] Transform cameraHoldder;
    private Transform this_Camera;
    [SerializeField] float speed, strength;
    public float duration;


    // Start is called before the first frame update
    void Start()
    {
        this_Camera = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (duration>0)
        {
            set_Shake();
            duration-=Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraHoldder.position, Time.deltaTime * Mathf.Abs(speed)); ;
        }
        
    }
    
    void set_Shake()
    {
        /*
        if (transform.position==shakePos)
        {
            shakePos = cameraHoldder.position + new Vector3(Random.Range(-strength, strength), Random.Range(-strength, strength), 0);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, shakePos, Time.deltaTime * Mathf.Abs(speed));
        }*/

        this_Camera.Translate(Random.Range(-strength, strength), Random.Range(-strength, strength), 0);



    }
    
    
 }
