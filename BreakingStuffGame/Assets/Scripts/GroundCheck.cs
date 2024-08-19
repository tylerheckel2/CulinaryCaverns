using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Block"))
        {
            transform.parent.GetComponent<PlayerMovement>().onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground") || collision.CompareTag("Block"))
        {
            transform.parent.GetComponent<PlayerMovement>().onGround = false;
        }
    }
}
