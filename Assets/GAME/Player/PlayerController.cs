using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerMovement playerMovement;
    
    public void Initialize()
    {
        playerMovement.AddOnMoveAction(playerAnimation.Run);
    }
    void Start()
    {
        Initialize();
    }

    private void Update()
    {
        playerMovement.Move();
    }
}
