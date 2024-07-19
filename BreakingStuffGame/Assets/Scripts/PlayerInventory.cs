using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject inventorySlotPrefab;
    public ItemCollector itemCollector;
    public int inventoryWidth;
    public int inventoryHeight;

    private void Start()
    {
        /*inventorySlots = new InventorySlot[inventoryWidth, inventoryHeight];
        uiSlots = new GameObject[inventoryWidth, inventoryHeight];*/
        /*Add(ItemClass(item);*/
    }

    void UpdateUI()
    {

    }

    public void Add(ItemClass item)
    {
        itemCollector.NumOneCollector();
        
        /*if (item == )
        {
            itemCollector.NumOneCollector();
        }
        else if (item == )
        {
            itemCollector.NumTwoCollector();
        }
        else
        {
            return;
        }*/
    }
}
