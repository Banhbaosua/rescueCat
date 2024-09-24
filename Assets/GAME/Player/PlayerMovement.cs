using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] PlayerMovementData playerMovementData;
    [Header("Movement Input")]
    [SerializeField] JoyStick joyStick;
    private Vector3 _velocity;
    private float _speed => playerMovementData.Speed;
    private float _stamina => playerMovementData.Stamina;
    public Action OnPlayerMove;
    public void Init()
    {
        
    }

    public void AddOnMoveAction(Action action)
    {
        OnPlayerMove += action;
    }
    public void Move()
    {
        _velocity.x = joyStick.Direction.x;
        _velocity.z = joyStick.Direction.y;
        characterController.Move(_speed * Time.deltaTime * _velocity);
        OnPlayerMove?.Invoke();
    }
}
