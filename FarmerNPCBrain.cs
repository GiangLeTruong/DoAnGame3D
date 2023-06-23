using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerNPCBrain : MonoBehaviour
{
    public bool farmer_Work1=false, farmer_Work2 = false, farmer_Talk1 = false, farmer_Talk2 = false;
    private Animator this_Animator;
    // Start is called before the first frame update
    void Start()
    {
        this_Animator=this.GetComponent<Animator>();
        set_Animation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void set_Animation()
    {
        if (farmer_Work1) this_Animator.SetBool("Work1", true);
        else if (farmer_Work2) this_Animator.SetBool("Work2", true);
        else if (farmer_Talk1) this_Animator.SetBool("Talk1", true);
        else if (farmer_Talk2) this_Animator.SetBool("Talk2", true);
    }
}
