using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour
{
    public float time_ToLive;
    private float time_Counting;
    
    // Update is called once per frame
    void Update()
    {
        if(time_Counting<= time_ToLive)
        {
            time_Counting += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
