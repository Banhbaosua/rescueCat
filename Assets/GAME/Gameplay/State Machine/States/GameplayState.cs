using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameplayStateBehaviour
{
    private TsunamiBehaviour tsunami;
    private FinishLine finishLine;
    private PlayerMovement playerMovement;
    private SpeedMeterController speedMeterController;
    public GameplayState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        stateMachineController.ParentBehaviour.PlayerController.enabled = true;
        stateMachineController.ParentBehaviour.JoyStick.enabled = true;
        stateMachineController.ParentBehaviour.CatCatcher.enabled = true;
        stateMachineController.ParentBehaviour.PlayerController.PlayerAnimation.enabled = true;
        tsunami.enabled = true;
        tsunami.OnTsunamiHit += Lose;
        finishLine.LineReach += Win;
        speedMeterController.Init(playerMovement);
        playerMovement.AddOnMoveAction(speedMeterController.RotateArrow);
        playerMovement.AddOnStopAction(speedMeterController.ResetArrow);
    }

    public override void OnStateDisabled()
    {
        tsunami.OnTsunamiHit -= Lose;
        finishLine.LineReach -= Win;
        stateMachineController.ParentBehaviour.PlayerController.enabled = false;
        stateMachineController.ParentBehaviour.JoyStick.enabled = false;
        stateMachineController.ParentBehaviour.CatCatcher.enabled = false;
    }

    public override void OnStateRegistered()
    {
        tsunami = stateMachineController.ParentBehaviour.TsunamiBehaviour;
        finishLine = stateMachineController.ParentBehaviour.FinishLine;
        playerMovement = stateMachineController.ParentBehaviour.PlayerMovement;
        speedMeterController = stateMachineController.ParentBehaviour.SpeedMeter;
    }

    public override void Update()
    {
        
    }

    void Lose()
    {
        stateMachineController.SetState(GameplayStatemachineController.GameState.GameLose);
    }

    void Win()
    {
        stateMachineController.SetState(GameplayStatemachineController.GameState.GameWin);
    }
}
