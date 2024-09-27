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
        RegisterState(new SpeedUpgradeState(this), GameState.SpeedUpgrade);
        RegisterState(new GameLoseState(this), GameState.GameLose);
        RegisterState(new GameWinState(this), GameState.GameWin);
    }

    public enum GameState
    {
        EmptyState = 0,
        SpeedUpgrade = 1,
        BoostStart = 2,
        GamePlay = 3,
        GameLose = 4,
        GameWin = 5,
    }
}
