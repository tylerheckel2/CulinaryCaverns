using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public TerrainHandler terrainhandler;
    public PlayerInventory inventory;
    public ChatBubble chatBubble;
    public bool chatBubbleShowing = false;
    public bool inventoryShowing = false;
    private Rigidbody2D playerRigidBody;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirX = 0f;
    private bool hit;
    public bool onGround;
    private bool doubleJump;

    public int playerRange;
    public Vector2Int mousePos;


    [SerializeField] private float playerSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    public AudioSource jumpSoundEffect;
    public AudioSource mineSoundEffect;

    private enum MovementState { idle, running, runningMining, jumping, falling, mining }

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        inventory = GetComponent<PlayerInventory>();
    }
    private void Update()
    {
        int playerposX = Mathf.RoundToInt(transform.position.x-0.5f);
        int playerposY = Mathf.RoundToInt(transform.position.y-0.5f);
        mousePos.x = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 0.5f);
        mousePos.y = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - 0.5f);

        dirX = Input.GetAxisRaw("Horizontal");
        playerRigidBody.velocity = new Vector2(dirX * playerSpeed, playerRigidBody.velocity.y);


        hit = Input.GetMouseButton(0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryShowing = !inventoryShowing;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            chatBubbleShowing = !chatBubbleShowing;
        }

        /*if (Vector2.Distance(transform.position, mousePos) <= playerRange && Vector2.Distance(transform.position, mousePos) > 0.1f)
        {
            if (hit)
            {
                mineSoundEffect.Play();
                *//*terrainhandler.RemoveTile(mousePos.x, mousePos.y);*//*
            }
        }*/

        if (Input.GetKey(KeyCode.L) && (!(dirX > 0f)) && !(dirX < 0f))
        {
            mineSoundEffect.Play();
            terrainhandler.RemoveTile(playerposX + 1, playerposY - 1);
            terrainhandler.RemoveTile(playerposX + 1, playerposY);
        }
        if (Input.GetKey(KeyCode.J) && (!(dirX > 0f)) && !(dirX < 0f))
        {
            mineSoundEffect.Play();
            terrainhandler.RemoveTile(playerposX - 1, playerposY - 1);
            terrainhandler.RemoveTile(playerposX - 1, playerposY);
        }
        if (Input.GetKey(KeyCode.I) && (!(dirX > 0f)) && !(dirX < 0f))
        {
            mineSoundEffect.Play();
            terrainhandler.RemoveTile(playerposX, playerposY + 1);
        }
        if (Input.GetKey(KeyCode.K) && (!(dirX > 0f)) && !(dirX < 0f))
        {
            mineSoundEffect.Play();
            terrainhandler.RemoveTile(playerposX, playerposY - 2);
        }

        inventory.inventoryUI.SetActive(inventoryShowing);

        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {

            if (IsGrounded() || doubleJump)
            {
                jumpSoundEffect.Play();
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }

        /*if (Input.GetButtonDown("Jump") && playerRigidBody.velocity.y > 0f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y * 0.5f);
        }*/

            UpdateAnimationState();
    }

    public bool IsGrounded()
    {
        return onGround;
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            /*if (transform.position.y >= 29f)
            {*/
                state = MovementState.running;
                sprite.flipX = false;
            /*}*/
            /*else
            {
                state = MovementState.runningMining;
                sprite.flipX = false;
            }*/
        }
        else if (dirX < 0f)
        {
            /*if (transform.position.y >= 29f)
            {*/
                state = MovementState.running;
                sprite.flipX = true;
            /*}*/
            /*else
            {
                state = MovementState.runningMining;
                sprite.flipX = true;
            }*/
        }
        else
        {
            state = MovementState.idle;
        }
        if ((Input.GetKey(KeyCode.I) || Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L)) && (!(dirX > 0f)) && !(dirX < 0f))
        {
            state = MovementState.mining;
            if (Input.GetKey(KeyCode.L))
            {
                sprite.flipX = false;
            }
            else if (Input.GetKey(KeyCode.J))
            {
                sprite.flipX = true;
            }
        }

        anim.SetInteger("State", (int)state);
    }
}
