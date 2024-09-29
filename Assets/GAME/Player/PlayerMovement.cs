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
    private float UpgradeSpeed => playerMovementData.UpgradedSpeed;
    private float _stamina => playerMovementData.Stamina;
    private Action OnPlayerMove;
    private Action OnPlayerStop;
    public PlayerMovementData Data => playerMovementData;
    public void Move(Vector2 direction)
    {
        _velocity.x = direction.x;
        _velocity.z = direction.y;
        _velocity.y = Physics.gravity.y;
        characterController.Move(GetSpeed()/10 * Time.deltaTime * _velocity);
        Look(_velocity);
    }

    public void Stop()
    {
        OnPlayerStop?.Invoke();
    }

    public float GetSpeed()
    {
        return BaseSpeed + BoostedSpeed + UpgradeSpeed;
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
