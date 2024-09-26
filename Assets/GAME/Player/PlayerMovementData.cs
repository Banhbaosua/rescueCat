using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerMovementData",menuName = "Player/PlayerMovementData")]
public class PlayerMovementData : ScriptableObject
{
    [SerializeField] float speed;
    [SerializeField] float stamina;
    public float Speed => speed;
    public float Stamina => stamina;

    public void SpeedInc(float speed)
    {
        this.speed += speed;
    }
}
