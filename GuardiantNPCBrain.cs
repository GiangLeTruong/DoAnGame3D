using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardiantNPCBrain : MonoBehaviour
{
    public bool guardiant_Guarding = false, guardiant_Training = false;
    private Animator this_Animator;
    // Start is called before the first frame update
    void Start()
    {
        this_Animator = this.GetComponent<Animator>();
        set_Animation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void set_Animation()
    {
        if (guardiant_Guarding) this_Animator.SetBool("Guarding", true);
        else if (guardiant_Training) this_Animator.SetBool("Training", true);
    }
}
