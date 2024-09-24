using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] JoyStick joyStick;
    void Start()
    {
        
    }

    private void Update()
    {
        if (joyStick.Touched)
            MoveBehaviour();
        else
            IdleBehaviour();
    }

    void MoveBehaviour()
    {
        playerMovement.Move(joyStick.Direction);
        playerAnimation.Run();
    }

    void IdleBehaviour()
    {
        playerMovement.Move(Vector2.zero);
        playerAnimation.Idle();
    }
}
