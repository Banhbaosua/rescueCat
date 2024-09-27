using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoseState : GameplayStateBehaviour
{
    public GameLoseState(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }

    public override void OnStateActivated()
    {
        Time.timeScale = 0;
        Debug.Log("end game");
        stateMachineController.ParentBehaviour.LosePanel.gameObject.SetActive(true);
    }

    public override void OnStateDisabled()
    {
        Time.timeScale = 1f;
    }

    public override void OnStateRegistered()
    {

    }

    public override void Update()
    {

    }
}
