using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BoostState : GameplayStateBehaviour
{
    private float boostStateTimer;
    public BoostState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        EnhancedTouchSupport.Enable();
        
        boostStateTimer = 0;
        Touch.onFingerDown += OnFingerDown;
        stateMachineController.ParentBehaviour.SpeedBoost.Init();
        stateMachineController.ParentBehaviour.PlayerController.enabled = false;
        stateMachineController.ParentBehaviour.JoyStick.enabled = false;
    }

    public override void OnStateDisabled()
    {
        Touch.onFingerDown -= OnFingerDown;
    }

    private void OnFingerDown(Finger _)
    {
        stateMachineController.ParentBehaviour.SpeedBoost.Boost();
    }

    public override void OnStateRegistered()
    {
        
    }

    public override void Update()
    {
        if (boostStateTimer > stateMachineController.ParentBehaviour.SpeedBoost.BoostValueTTL)
            stateMachineController.SetState(GameplayStatemachineController.GameState.GamePlay);
        boostStateTimer+= Time.deltaTime;
    }
}
