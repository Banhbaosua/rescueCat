using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class GameplayManager : MonoBehaviour
{
    private GameplayStatemachineController stateMachine;
    private void Awake()
    {
        stateMachine = new GameplayStatemachineController();
        stateMachine.Initialise(this, GameplayStatemachineController.GameState.BoostStart);
    }
    private void Start()
    {
    }

    private void Update()
    {
        stateMachine.ActiveStateBehaviour.Update();
    }
}
