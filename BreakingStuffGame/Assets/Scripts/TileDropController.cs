using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileDropController : MonoBehaviour
{
    public ItemClass item;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //add to the player's inventory
            if (col.GetComponent<PlayerInventory>().Add(item))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
