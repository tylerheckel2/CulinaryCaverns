using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInventory : MonoBehaviour
{
    public int stackLimit = 64;
    public Vector2 offset;
    public Vector2 multiplier;
    public GameObject inventoryUI;
    public GameObject inventorySlotPrefab;

    public int inventoryWidth;
    public int inventoryHeight;
    public InventorySlot[,] inventorySlots;
    public GameObject[,] uiSlots;
    public TileAtlas tileAtlas;
    public ChatBubble chatBubble;
    public AudioSource itemCollectSoundEffect;
    public int numOne = 0;
    public int numTwo = 0;
    public int numThree = 0;
    public int numFour = 0;
    public int totalFood = 0;
    public bool numOneCollected = false;
    public bool numTwoCollected = false;
    public bool numThreeCollected = false;
    public bool numFourCollected = false;
    public bool totalFoodCollected = false;

    public bool levelContainsOrder = true;

    private void Start()
    {
        inventorySlots = new InventorySlot[inventoryWidth, inventoryHeight];
        uiSlots = new GameObject[inventoryWidth, inventoryHeight];
        SetupUI();
        UpdateInventoryUI();
    }

    void SetupUI()
    {
        for (int x = 0; x < inventoryWidth; x++)
        {
            for (int y = 0; y < inventoryHeight; y++)
            {
                GameObject inventorySlot = Instantiate(inventorySlotPrefab, inventoryUI.transform.GetChild(0).transform);
                inventorySlot.GetComponent<RectTransform>().localPosition = new Vector3((x * multiplier.x) + offset.x, (y * multiplier.y) + offset.y);
                uiSlots[x, y] = inventorySlot;
                inventorySlots[x, y] = null;
            }
        }
    }

    void UpdateInventoryUI()
    {
        for (int x = 0; x < inventoryWidth; x++)
        {
            for (int y = 0; y < inventoryHeight; y++)
            {
                if (inventorySlots[x, y] == null)
                {
                    uiSlots[x, y].transform.GetChild(0).GetComponent<Image>().sprite = null;
                    uiSlots[x, y].transform.GetChild(0).GetComponent<Image>().enabled = false;

                    uiSlots[x, y].transform.GetChild(1).GetComponent<Text>().text = "0";
                    uiSlots[x, y].transform.GetChild(1).GetComponent<Text>().enabled = false;
                }
                else
                {
                    uiSlots[x, y].transform.GetChild(0).GetComponent<Image>().enabled = true;
                    uiSlots[x, y].transform.GetChild(0).GetComponent<Image>().sprite = inventorySlots[x,y].item.sprite;

                    uiSlots[x, y].transform.GetChild(1).GetComponent<Text>().text = inventorySlots[x,y].quantity.ToString();
                    uiSlots[x, y].transform.GetChild(1).GetComponent<Text>().enabled = true;
                }
            }
        }
    }

    public bool Add(ItemClass item)
    {
        Vector2Int itemPos = Contains(item);
        bool added = false;

        if (itemPos != Vector2Int.one * -1)
        {
            itemCollectSoundEffect.Play();
            inventorySlots[itemPos.x, itemPos.y].quantity += 1;
            if (inventorySlots[itemPos.x, itemPos.y].item.sprite == tileAtlas.numOne.tileSprites[1])
            {
                numOne++;
                totalFood++;
                if (levelContainsOrder)
                {
                    if (numOne >= chatBubble.numOne)
                    {
                        numOneCollected = true;
                    }
                    if (totalFood >= chatBubble.totalFood)
                    {
                        totalFoodCollected = true;
                    }
                }
            }
            if (inventorySlots[itemPos.x, itemPos.y].item.sprite == tileAtlas.numTwo.tileSprites[1])
            {
                numTwo++;
                totalFood++;
                if (levelContainsOrder)
                {
                    if (numTwo >= chatBubble.numTwo)
                    {
                        numTwoCollected = true;
                    }
                    if (totalFood >= chatBubble.totalFood)
                    {
                        totalFoodCollected = true;
                    }
                }
            }
            if (inventorySlots[itemPos.x, itemPos.y].item.sprite == tileAtlas.numThree.tileSprites[1])
            {
                numThree++;
                totalFood++;
                if (levelContainsOrder)
                {
                    if (numThree >= chatBubble.numThree)
                    {
                        numThreeCollected = true;
                    }
                    if (totalFood >= chatBubble.totalFood)
                    {
                        totalFoodCollected = true;
                    }
                }
            }
            if (inventorySlots[itemPos.x, itemPos.y].item.sprite == tileAtlas.numFour.tileSprites[1])
            {
                numFour++;
                totalFood++;
                if (levelContainsOrder)
                {
                    if (numFour >= chatBubble.numFour)
                    {
                        numFourCollected = true;
                    }
                    if (totalFood >= chatBubble.totalFood)
                    {
                        totalFoodCollected = true;
                    }
                }
            }
            added = true;
        }
        if (!added) {
            for (int y = inventoryHeight - 1; y >= 0; y--)
            {
                if (added)
                    break;
                for (int x = 0; x < inventoryWidth; x++)
                {
                    if (inventorySlots[x, y] == null)
                    {
                        itemCollectSoundEffect.Play();
                        inventorySlots[x, y] = new InventorySlot { item = item, position = new Vector2Int(x, y), quantity = 1 };
                        if (inventorySlots[x, y].item.sprite == tileAtlas.numOne.tileSprites[1])
                        {
                            numOne++;
                            totalFood++;
                        }
                        if (inventorySlots[x, y].item.sprite == tileAtlas.numTwo.tileSprites[1])
                        {
                            numTwo++;
                            totalFood++;
                        }
                        if (inventorySlots[x, y].item.sprite == tileAtlas.numThree.tileSprites[1])
                        {
                            numThree++;
                            totalFood++;
                        }
                        if (inventorySlots[x, y].item.sprite == tileAtlas.numFour.tileSprites[1])
                        {
                            numFour++;
                            totalFood++;
                        }
                        added = true;
                        break;
                    }
                }
            }
        
        }
        UpdateInventoryUI();
        return added;
     }
    
    public Vector2Int Contains(ItemClass item)
    {
        for (int y = inventoryHeight - 1; y >= 0; y--)
        {
            for (int x = 0; x < inventoryWidth; x++)
            {
                if (inventorySlots[x, y] != null)
                {
                    if (inventorySlots[x, y].item.sprite == item.sprite)
                    {
                        return new Vector2Int(x, y);
                    }
                }
            }
        }
        return Vector2Int.one * -1; 
    }
}
