using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;
public abstract class GameplayStateBehaviour : StateBehaviour<GameplayStatemachineController>
{
    protected GameplayStateBehaviour(GameplayStatemachineController stateMachineController) : base(stateMachineController)
    {
    }
}
