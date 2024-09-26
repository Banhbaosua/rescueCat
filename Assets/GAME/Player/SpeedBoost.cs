using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] PlayerMovementData movementData;
    [SerializeField] float boostValueTTL;
    public event Action<float> OnSpeedBoost;
    private float _boostedValue;
    private float _maxStamina;
    private float _currentStamina;
    public float BoostValueTTL => boostValueTTL;
    public float BoostedValue => _boostedValue/10f;
    public void Init()
    {
        _maxStamina = movementData.Stamina;
        _currentStamina = _maxStamina;
        _boostedValue = 0;
    }

    public void Boost()
    {
        if (_currentStamina > 0)
        {
            _boostedValue += _maxStamina/10f; 
            _currentStamina -= _maxStamina/10f;
            OnSpeedBoost?.Invoke(_currentStamina/_maxStamina);
        }
    }

    public void AddBoostAction(Action<float> action)
    {
        OnSpeedBoost += action;
    }
}
