using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    public Action OnTsunamiHit;
    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += speed * Time.deltaTime * Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            OnTsunamiHit?.Invoke();
        }
    }
}
