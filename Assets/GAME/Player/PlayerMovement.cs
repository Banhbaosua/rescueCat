using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] PlayerMovementData playerMovementData;
    private Vector3 _velocity;
    private float _speed => playerMovementData.Speed;
    private float _stamina => playerMovementData.Stamina;
    public void Move(Vector2 direction)
    {
        _velocity.x = direction.x;
        _velocity.z = direction.y;
        _velocity.y = Physics.gravity.y;
        characterController.Move(_speed * Time.deltaTime * _velocity);
        Look(_velocity);
    }

    public void Look(Vector3 direction)
    {
        if (direction.x == 0 && direction.z == 0) return;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
