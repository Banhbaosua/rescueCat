using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] SpeedMeterController speedMeter;
    [SerializeField] SpeedBoost speedBoost;
    [SerializeField] SpeedUpgrade speedUpgrade;
    [SerializeField] PlayerController playerController;
    [SerializeField] JoyStick joyStick;
    [SerializeField] StaminaBar staminaBar;
    [SerializeField] PlayerMovement playerMovement;
    private GameplayStatemachineController stateMachine;
    public SpeedMeterController SpeedMeter => speedMeter;
    public SpeedBoost SpeedBoost => speedBoost;
    public PlayerController PlayerController => playerController;
    public JoyStick JoyStick => joyStick;
    public StaminaBar StaminaBar => staminaBar;
    public SpeedUpgrade SpeedUpgrade => speedUpgrade;
    public PlayerMovement PlayerMovement => playerMovement;
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
