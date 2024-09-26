using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerMovementData",menuName = "Player/PlayerMovementData")]
public class PlayerMovementData : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float stamina;
    private float upgradedSpeed;
    public float Speed => speed;
    public float Stamina => stamina;
    public float UpgradedSpeed => upgradedSpeed;

    public void SpeedInc(float speed)
    {
        upgradedSpeed += speed;
    }

    public  void ResetUpgrade()
    {
        upgradedSpeed = 0;
    }
}
