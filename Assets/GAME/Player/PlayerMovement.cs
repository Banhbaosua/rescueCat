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
    public Action OnPlayerMove;
    public void AddOnMoveAction(Action action)
    {
        OnPlayerMove += action;
    }
    public void Move(Vector2 direction)
    {
        _velocity.x = direction.x;
        _velocity.z = direction.y;
        characterController.Move(_speed * Time.deltaTime * _velocity);
        OnPlayerMove?.Invoke();
    }
}
