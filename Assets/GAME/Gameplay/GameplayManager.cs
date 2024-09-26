using Cinemachine;
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
    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera speedPhaseCam;
    [SerializeField] CinemachineVirtualCamera gameplayCam;
    [Header("Spawner")]
    [SerializeField] List<Spawner> spawners;
    private GameplayStatemachineController stateMachine;
    public SpeedMeterController SpeedMeter => speedMeter;
    public SpeedBoost SpeedBoost => speedBoost;
    public PlayerController PlayerController => playerController;
    public JoyStick JoyStick => joyStick;
    public StaminaBar StaminaBar => staminaBar;
    public SpeedUpgrade SpeedUpgrade => speedUpgrade;
    public PlayerMovement PlayerMovement => playerMovement;
    public CinemachineVirtualCamera SpeedPhaseCam => speedPhaseCam;
    private void Awake()
    {
        stateMachine = new GameplayStatemachineController();
        stateMachine.Initialise(this, GameplayStatemachineController.GameState.SpeedUpgrade);
        foreach (var spawner in spawners)
        {
            spawner.Spawn();
        }
        //test only
        playerMovement.Data.ResetUpgrade();
    }
    private void Update()
    {
        stateMachine.ActiveStateBehaviour.Update();
    }
}
