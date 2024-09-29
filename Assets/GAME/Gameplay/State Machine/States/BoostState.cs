using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class BoostState : GameplayStateBehaviour
{
    private float boostStateTimer;
    private SpeedBoost speedBoost;
    private SpeedMeterController speedMeterController;
    private StaminaBar staminaBar;
    private PlayerMovement playerMovement;
    public BoostState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        EnhancedTouchSupport.Enable();
        stateMachineController.ParentBehaviour.JoyStick.enabled = false;
        stateMachineController.ParentBehaviour.TsunamiBehaviour.enabled = true;
        speedBoost.enabled = true;
        boostStateTimer = 0;
        Touch.onFingerDown += OnFingerDown;
        speedBoost.Init();
        speedBoost.AddBoostAction(speedMeterController.UpdateMaxSpeedText);
        speedBoost.AddBoostAction(staminaBar.UpdateFill);
    }

    public override void OnStateDisabled()
    {
        Touch.onFingerDown -= OnFingerDown;
        speedBoost.enabled = false;
    }

    private void OnFingerDown(Finger _)
    {
        stateMachineController.ParentBehaviour.SpeedBoost.Boost();
    }

    public override void OnStateRegistered()
    {
        speedBoost = stateMachineController.ParentBehaviour.SpeedBoost;
        speedMeterController = stateMachineController.ParentBehaviour.SpeedMeter;
        staminaBar = stateMachineController.ParentBehaviour.StaminaBar;
        playerMovement = stateMachineController.ParentBehaviour.PlayerMovement;
    }

    public override void Update()
    {
        if (boostStateTimer > stateMachineController.ParentBehaviour.SpeedBoost.BoostPhaseTime)
            stateMachineController.SetState(GameplayStatemachineController.GameState.GamePlay);
        boostStateTimer+= Time.deltaTime;
    }
}
