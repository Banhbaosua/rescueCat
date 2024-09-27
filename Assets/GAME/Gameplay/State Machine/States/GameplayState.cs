using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : GameplayStateBehaviour
{
    public GameplayState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        stateMachineController.ParentBehaviour.PlayerController.enabled = true;
        stateMachineController.ParentBehaviour.JoyStick.enabled = true;
        stateMachineController.ParentBehaviour.CatCatcher.enabled = true;
    }

    public override void OnStateDisabled()
    {
        
    }

    public override void OnStateRegistered()
    {
        
    }

    public override void Update()
    {
        
    }
}
