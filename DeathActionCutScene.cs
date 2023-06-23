using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathActionCutScene : MonoBehaviour
{
    Animator animator;
    // Update is called once per frame
    private void Start()
    {
        animator=this.GetComponent<Animator>();
    }
    void Update()
    {
        if(Time.time>93)
        {
            animator.Play("Death");
        }
    }
}
