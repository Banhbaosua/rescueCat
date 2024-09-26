using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class SpeedUpgradeState : GameplayStateBehaviour
{
    private PlayerMovementData playerMovementData;
    private SpeedUpgrade speedUpgrade;
    public SpeedUpgradeState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        EnhancedTouchSupport.Enable();

        speedUpgrade.Button.onClick.AddListener(() => playerMovementData.SpeedInc(speedUpgrade.SpeedPerUpgrade));
    }

    public override void OnStateDisabled()
    {
        
    }

    public override void OnStateRegistered()
    {
        playerMovementData = stateMachineController.ParentBehaviour.PlayerMovement.Data;
        speedUpgrade = stateMachineController.ParentBehaviour.SpeedUpgrade;
    }

    public override void Update()
    {
        
    }
}
