using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
public class SpeedUpgradeState : GameplayStateBehaviour
{
    private PlayerMovementData playerMovementData;
    private SpeedUpgrade speedUpgrade;
    private JoyStick joyStick;
    private SpeedMeterController speedMeterController;
    private PlayerMovement playerMovement;
    public SpeedUpgradeState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        EnhancedTouchSupport.Enable();
        speedUpgrade.Init();
        speedMeterController.enabled = true;
        speedMeterController.Init(playerMovement);

        //speedUpgrade.RaceButton.onClick.AddListener(() => ChangeToBoostState(null));
        EventTrigger.Entry clickEvent = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        clickEvent.callback.AddListener(ChangeToBoostState);
        speedUpgrade.RaceTrigger.triggers.Add(clickEvent);
        joyStick.enabled = false;
    }

    void ChangeToBoostState(BaseEventData _)
    {
        stateMachineController.SetState(GameplayStatemachineController.GameState.BoostStart);
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
        playerMovement = stateMachineController.ParentBehaviour.PlayerMovement;
        speedMeterController = stateMachineController.ParentBehaviour.SpeedMeter;
    }

    public override void Update()
    {
        
    }
}
