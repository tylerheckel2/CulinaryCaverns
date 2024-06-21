using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    public InputAction MoveAction;
    Vector2 move;
    [SerializeField] private float playerSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(dirX * playerSpeed, playerRigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
