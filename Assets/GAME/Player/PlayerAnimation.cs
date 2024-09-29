using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    private const float ANIMATORMOVETHRESHOLD = 1f;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
    }
    public void Run()
    {
        animator.SetFloat("Movement Multiplier", ANIMATORMOVETHRESHOLD, 0.1f, Time.deltaTime);
    }

    public void Run(float value)
    {
        animator.SetFloat("Movement Multiplier", value, 0.1f, Time.deltaTime);
    }
}
