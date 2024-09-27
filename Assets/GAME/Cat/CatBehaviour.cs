using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatBehaviour : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Animator animator;
    [SerializeField] Collider triggerCol;
    [SerializeField] Rigidbody rb;
    private bool isCatched;
    private Transform destination;
    public bool IsCatched => isCatched;
    private void Start()
    {
        navMeshAgent.isStopped = true;
        animator.SetBool("Run", true);
        destination = GameObject.FindGameObjectWithTag("Destination").transform;
        Follow(destination);
    }

    private void Update()
    {
        if (!navMeshAgent.enabled) return;
        if (!navMeshAgent.isStopped)
        {
            animator.SetFloat("Movement Speed", 1f, 0.1f, Time.deltaTime);
            navMeshAgent.SetDestination(destination.position);
        }
        else
        {
            animator.SetFloat("Movement Speed",0,0.1f,Time.deltaTime);
        }
    }

    public void Run()
    {
        navMeshAgent.isStopped = false;
    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }

    public void Follow(Transform destination)
    {
        this.destination = destination;
    }

    public void Catched()
    {
        isCatched = true;
    }

    public void Hold()
    {
        navMeshAgent.enabled = false;
        rb.isKinematic = true;
    }

    public void SetSpeed(float speed)
    {
        navMeshAgent.speed = speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Run();
            triggerCol.enabled = false;
        }
    }
}
