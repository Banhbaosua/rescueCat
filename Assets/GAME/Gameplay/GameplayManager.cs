using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] SpeedMeterController speedMeter;
    [SerializeField] SpeedBoost speedBoost;
    [SerializeField] PlayerController playerController;
    [SerializeField] JoyStick joyStick;
    [SerializeField] StaminaBar staminaBar;
    private GameplayStatemachineController stateMachine;
    public SpeedMeterController SpeedMeter => speedMeter;
    public SpeedBoost SpeedBoost => speedBoost;
    public PlayerController PlayerController => playerController;
    public JoyStick JoyStick => joyStick;
    public StaminaBar StaminaBar => staminaBar;
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
