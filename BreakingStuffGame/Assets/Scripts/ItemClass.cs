using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass
{
    public enum ItemType
    {
        block,
        tool
    }

    public ItemType itemType;

    public TileClass tile;

    public string name;
    public Sprite sprite;


    public ItemClass(TileClass _tile)
    {
        name = _tile.name;
        sprite = _tile.tileSprites[0];
        itemType = ItemType.block;
    }
}
