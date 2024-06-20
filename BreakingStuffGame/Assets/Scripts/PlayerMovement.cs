using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public InputAction MoveAction;
    [SerializeField] private Rigidbody2D playerRigidBody;
    Vector2 move;
    [SerializeField] private float playerSpeed = 5f;

    private void OnEnable()
    {
        MoveAction.Enable();
    }
    private void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 position = playerRigidBody.position + move * playerSpeed * Time.deltaTime;
        playerRigidBody.MovePosition(position);
    }

}
