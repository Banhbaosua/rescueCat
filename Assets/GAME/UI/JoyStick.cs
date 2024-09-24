using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class JoyStick : MonoBehaviour
{
    [SerializeField] RectTransform background;
    [SerializeField] RectTransform handle;
    private Vector2 _input;
    private Vector2 _joystickPos;
    private Vector2 _direction;
    public Vector2 Direction => _direction;
    private void OnFingerUp(Finger obj)
    {
        background.gameObject.SetActive(false);
        _input = Vector2.zero;
    }
    private void OnFingerDown(Finger finger)
    {
        background.gameObject.SetActive(true);
        var fingerPos = finger.screenPosition;
        _joystickPos = fingerPos;
        background.position = fingerPos;
        handle.position = fingerPos;
        handle.anchoredPosition = Vector2.zero;
    }

    void OnFingerMove(Finger finger)
    {
        Vector2 direction = finger.currentTouch.screenPosition - _joystickPos;
        if (direction.magnitude > background.sizeDelta.x / 2f)
            _input = direction.normalized;
        else
            _input = direction / (background.sizeDelta.x / 2f);
        
        _direction = direction.normalized;
        handle.anchoredPosition = _input*background.sizeDelta.x/2f;
    }
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        Touch.onFingerMove += OnFingerMove;
        Touch.onFingerDown += OnFingerDown;
        Touch.onFingerUp += OnFingerUp;
    }
    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        Touch.onFingerMove -= OnFingerMove;
        Touch.onFingerDown -= OnFingerDown;
        Touch.onFingerUp -= OnFingerUp;
    }
}
