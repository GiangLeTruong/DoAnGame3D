using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessing_Manager : MonoBehaviour
{
    public float pp_duration=0f;
    ChromaticAberration pp_Stun;
    float stun_rate=1;
    float decrease_rate = 0.001f;
    [SerializeField] VolumeProfile vp;
    // Start is called before the first frame update
    void Start()
    {
        
        //pp_Stun = gameObject.GetComponent<ChromaticAberration>();
    }

    // Update is called once per frame
    void Update()
    {
        //set_Stuning();
    }

    void set_Stuning()
    {
        if(pp_duration>0)
        {
            pp_Stun.intensity.value=stun_rate;
            pp_duration-=Time.deltaTime;
        }
        else
        {
            pp_Stun.intensity.value -= decrease_rate;
        }
    }



}
