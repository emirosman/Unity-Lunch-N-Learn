using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSample : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("fall");
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("run");
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                animator.SetTrigger("jump");
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                animator.SetTrigger("idle");
            }
        }
    }
}
