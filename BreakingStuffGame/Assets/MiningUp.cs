using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningUp : MonoBehaviour
{
    private List<Collider2D> collidingBlocks = new List<Collider2D>(); // To keep track of blocks in the trigger area
    public TerrainHandler terrainHandler;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object is in the block layer
        if (collision.gameObject.CompareTag("Block"))
        {
            collidingBlocks.Add(collision);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Remove the block from the list when it exits the trigger area
        if (collision.gameObject.CompareTag("Block"))
        {
            collidingBlocks.Remove(collision);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.I)) // Check for left mouse button click
        {
            // Create a copy of the list to iterate over
            List<Collider2D> blocksToDestroy = new List<Collider2D>(collidingBlocks);

            // Destroy all blocks currently in the trigger area
            foreach (Collider2D block in blocksToDestroy)
            {
                if (collidingBlocks.Contains(block))
                {
                    /*int posX = Mathf.RoundToInt(block.transform.position.x);
                    int posY = Mathf.RoundToInt(block.transform.position.y);*/

                    Destroy(block.gameObject);
                    /*terrainHandler.RemoveTile(posX, posY);*/
                }
            }

            // Clear the list after destroying the blocks
            collidingBlocks.Clear();
        }
    }
}
