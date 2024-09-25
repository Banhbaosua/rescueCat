using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] PlayerMovementData playerMovementData;
    [SerializeField] SpeedBoost speedBoost;
    private Vector3 _velocity;
    private float BoostedSpeed => speedBoost.BoostedValue;
    private float BaseSpeed => playerMovementData.Speed;
    private float _stamina => playerMovementData.Stamina;
    private event Action OnPlayerMove;
    private event Action OnPlayerStop;
    public void Move(Vector2 direction)
    {
        if (direction.x == 0 && direction.y == 0)
        {
            OnPlayerStop?.Invoke();
            return;
        }
        _velocity.x = direction.x;
        _velocity.z = direction.y;
        _velocity.y = Physics.gravity.y;
        characterController.Move((GetSpeed()/10) * Time.deltaTime * _velocity);
        Look(_velocity);
    }

    public float GetSpeed()
    {
        return BaseSpeed + BoostedSpeed;
    }

    public void Look(Vector3 direction)
    {
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
        OnPlayerMove?.Invoke();
    }

    public void AddOnMoveAction(Action action)
    {
        OnPlayerMove += action;
    }

    public void AddOnStopAction(Action action) 
    { 
        OnPlayerStop += action;
    }
}
