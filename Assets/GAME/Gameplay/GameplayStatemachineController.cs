using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class GameplayStatemachineController : StateMachineController<GameplayManager, GameplayStatemachineController.GameState>
{
    protected override void RegisterStates()
    {
        RegisterState(new GameplayState(this), GameState.GamePlay);
        RegisterState(new BoostState(this),GameState.BoostStart);
    }

    public enum GameState
    {
        EmptyState = 0,
        BoostStart = 1,
        GamePlay = 2,
    }
}
