using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] JoyStick joyStick;
    Vector2 direction;
    private void Update()
    {
        if (joyStick.Touched)
            MoveBehaviour();
        else
            StopBehaviour();
    }

    void MoveBehaviour()
    {
        direction = joyStick.Direction;
        playerMovement.Move(joyStick.Direction);
        playerAnimation.Run();
    }

    void StopBehaviour()
    {
        direction = Vector2.Lerp(direction, Vector2.zero, Time.deltaTime);
        playerMovement.Move(direction);
        playerAnimation.Run(0);
    }
}
