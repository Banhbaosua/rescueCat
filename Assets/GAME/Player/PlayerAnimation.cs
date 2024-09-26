using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    private const float ANIMATORMOVETHRESHOLD = 1f;
    public void Run()
    {
        animator.SetBool("Run", true);
        animator.SetFloat("Movement Multiplier", ANIMATORMOVETHRESHOLD, 0.1f, Time.deltaTime);
    }

    public void Run(float value)
    {
        animator.SetBool("Run", false);
        animator.SetFloat("Movement Multiplier", 
            Mathf.Lerp(ANIMATORMOVETHRESHOLD,value,0.5f*Time.deltaTime), 
            0.1f, 
            Time.deltaTime);
    }
}
