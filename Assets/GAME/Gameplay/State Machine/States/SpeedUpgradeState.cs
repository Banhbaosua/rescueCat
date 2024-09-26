using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class SpeedUpgradeState : GameplayStateBehaviour
{
    private PlayerMovementData playerMovementData;
    private SpeedUpgrade speedUpgrade;
    private JoyStick joyStick;
    public SpeedUpgradeState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        EnhancedTouchSupport.Enable();
        speedUpgrade.Init();
        speedUpgrade.RaceButton.onClick.AddListener(() => stateMachineController.SetState(GameplayStatemachineController.GameState.BoostStart));
        joyStick.enabled = false;
    }

    public override void OnStateDisabled()
    {
        playerMovementData.SpeedInc(speedUpgrade.SpeedUpgradeValue);
        speedUpgrade.Button.onClick.RemoveAllListeners();
        speedUpgrade.gameObject.SetActive(false);
        stateMachineController.ParentBehaviour.SpeedPhaseCam.enabled = false;
        joyStick.enabled = true;
    }

    public override void OnStateRegistered()
    {
        playerMovementData = stateMachineController.ParentBehaviour.PlayerMovement.Data;
        speedUpgrade = stateMachineController.ParentBehaviour.SpeedUpgrade;
        joyStick = stateMachineController.ParentBehaviour.JoyStick;
    }

    public override void Update()
    {
        
    }
}
