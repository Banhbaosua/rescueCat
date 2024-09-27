using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] CatCatcher catCatcher;
    [SerializeField] JoyStick joyStick;
    [Header("Cat position on head")]
    [SerializeField] List<Transform> headPos;
    Vector2 direction;
    private void Awake()
    {
        catCatcher.Init(headPos);
    }
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
        direction = Vector2.Lerp(direction, Vector2.zero, 2f * Time.deltaTime);
        playerMovement.Move(direction);
        playerMovement.Stop();
        playerAnimation.Run(0);
    }
}
