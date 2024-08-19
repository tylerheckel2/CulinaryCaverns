using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TerrainHandler : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject tileDrop;

    [Header("Tile Atlas")]
    public TileAtlas tileAtlas;

    [Header("Trees")]
    public int treeChance = 10;
    public int minTreeHeight = 4;
    public int maxTreeHeight = 6;

    [Header("Generation Settings")]
    public bool generateCaves = true;
    public int worldSize = 125;
    public int chunkSize = 16;
    public float surfaceValue = 0.25f;
    public int dirtLayerHeight = 5;
    public float heightMultiplier = 4f;
    public int heightAddition = 25;

    [Header("Noise Settings")]
    public float caveFreq = 0.05f;
    public float terrainFreq = 0.05f;
    public float seed;
    public Texture2D caveNoiseTexture;

    [Header("Ore Settings")]
    public OreClass[] ores;

    private GameObject[] worldChunks;

    private List<Vector2> worldTiles = new List<Vector2>();
    private List<GameObject> worldTileObjects = new List<GameObject>();
    private List<TileClass> worldTileClasses = new List<TileClass>();

    private void OnValidate()
    {
        caveNoiseTexture = new Texture2D(worldSize, worldSize);
        ores[0].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[1].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[2].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[3].spreadTexture = new Texture2D(worldSize, worldSize);

        GenerateNoiseTexture(caveFreq, surfaceValue, caveNoiseTexture);
        //ores
        GenerateNoiseTexture(ores[0].rarity, ores[0].size, ores[0].spreadTexture);
        GenerateNoiseTexture(ores[1].rarity, ores[1].size, ores[1].spreadTexture);
        GenerateNoiseTexture(ores[2].rarity, ores[2].size, ores[2].spreadTexture);
        GenerateNoiseTexture(ores[3].rarity, ores[3].size, ores[3].spreadTexture);
    }

    private void Start()
    {
        caveNoiseTexture = new Texture2D(worldSize, worldSize);
        ores[0].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[1].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[2].spreadTexture = new Texture2D(worldSize, worldSize);
        ores[3].spreadTexture = new Texture2D(worldSize, worldSize);

        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture(caveFreq, surfaceValue, caveNoiseTexture);
        //ores
        GenerateNoiseTexture(ores[0].rarity, ores[0].size, ores[0].spreadTexture);
        GenerateNoiseTexture(ores[1].rarity, ores[1].size, ores[1].spreadTexture);
        GenerateNoiseTexture(ores[2].rarity, ores[2].size, ores[2].spreadTexture);
        GenerateNoiseTexture(ores[3].rarity, ores[3].size, ores[3].spreadTexture);
        CreateChunks();
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        TileClass tileClass;
        for (int x = 0; x < worldSize; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultiplier + heightAddition;

            for (int y = 0; y < worldSize; y++)
            {
                if (y >= height)
                {
                    break;
                }
                if (y < height - dirtLayerHeight)
                {
                    if (ores[0].spreadTexture.GetPixel(x, y).r > 0.5f)
                    {
                        tileClass = tileAtlas.numOne;
                    }
                    else if (ores[1].spreadTexture.GetPixel(x, y).r > 0.5f)
                    {
                        tileClass = tileAtlas.numTwo;
                    }
                    else if (ores[2].spreadTexture.GetPixel(x, y).r > 0.5f)
                    {
                        tileClass = tileAtlas.numThree;
                    }
                    else if (ores[3].spreadTexture.GetPixel(x, y).r > 0.5f)
                    {
                        tileClass = tileAtlas.numFour;
                    }
                    else
                    {
                        tileClass = tileAtlas.stone;
                    }
                }
                else if (y < height - 1)
                {
                    tileClass = tileAtlas.dirt;
                }
                else
                {
                    tileClass = tileAtlas.grass;
                }

                if (generateCaves)
                {
                    if (caveNoiseTexture.GetPixel(x, y).r > 0.5f)
                    {
                        PlaceTiler(tileClass, x, y);
                    }
                }
                else
                {
                    PlaceTiler(tileClass, x, y);
                }

                if (y >= height - 1)
                {
                    int t = Random.Range(0, treeChance);
                    if (t == 1)
                    {
                        //generate a tree
                        if (worldTiles.Contains(new Vector2(x, y)))
                        {
                            GenerateTree(x, y + 1);
                        }
                    }
                }
            }
        }
    }


    public void GenerateNoiseTexture(float frequency, float limit, Texture2D noiseTexture)
    {
        for (int x = 0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * frequency, (y + seed) * frequency);
                if (v > limit)
                {
                    noiseTexture.SetPixel(x, y, Color.white);
                }
                else
                {
                    noiseTexture.SetPixel(x, y, Color.black);
                }

            }
        }

        noiseTexture.Apply();
    }

    public void CreateChunks()
    {
        int numChunks = worldSize / chunkSize;
        worldChunks = new GameObject[numChunks];

        for (int i = 0; i < numChunks; i++)
        {
            GameObject newChunk = new GameObject();
            newChunk.name = i.ToString();
            newChunk.transform.parent = this.transform;
            worldChunks[i] = newChunk;
        }
    }

    public void RemoveTile(int x, int y)
    {
        if (worldTiles.Contains(new Vector2Int(x, y)) && x >= 0 && x <= worldSize && y >= 0 && y <= worldSize)
        {

            Destroy(worldTileObjects[worldTiles.IndexOf(new Vector2(x, y))]);

            if (worldTileClasses[worldTiles.IndexOf(new Vector2(x, y))].tileDrop)
            {
                GameObject newtileDrop = Instantiate(tileDrop, new Vector2(x, y + 0.5f), Quaternion.identity);
                newtileDrop.GetComponent<SpriteRenderer>().sprite = worldTileClasses[worldTiles.IndexOf(new Vector2(x, y))].tileSprites[1];
                ItemClass tileDropItem = new ItemClass(worldTileClasses[worldTiles.IndexOf(new Vector2(x, y))]);
                newtileDrop.GetComponent<TileDropController>().item = tileDropItem;
            }
            
            worldTileObjects.RemoveAt(worldTiles.IndexOf(new Vector2(x, y)));
            worldTileClasses.RemoveAt(worldTiles.IndexOf(new Vector2(x, y)));
            worldTiles.RemoveAt(worldTiles.IndexOf(new Vector2(x, y)));
        }
    }

    void GenerateTree(int x, int y)
    {
        int treeHeight = Random.Range(minTreeHeight, maxTreeHeight);
        for (int i = 0; i < treeHeight; i++)
        {
            PlaceTiler(tileAtlas.log, x, y + i);
        }

        PlaceTiler(tileAtlas.leaf, x, y + treeHeight);
        PlaceTiler(tileAtlas.leaf, x, y + treeHeight + 1);
        PlaceTiler(tileAtlas.leaf, x, y + treeHeight + 2);

        PlaceTiler(tileAtlas.leaf, x - 1, y + treeHeight);
        PlaceTiler(tileAtlas.leaf, x - 1, y + treeHeight + 1);

        PlaceTiler(tileAtlas.leaf, x + 1, y + treeHeight);
        PlaceTiler(tileAtlas.leaf, x + 1, y + treeHeight + 1);
    }

    public void PlaceTiler(TileClass tile, int x, int y)
    {
        if (!worldTiles.Contains(new Vector2Int(x, y)) && x >= 0 && x <= worldSize && y >= 0 && y <= worldSize)
        {
            bool backgroundElement = tile.inBackground;

            GameObject newTile = new GameObject();

            int chunkCoord = Mathf.FloorToInt((float)x / chunkSize);
            chunkCoord = Mathf.Clamp(chunkCoord, 0, worldChunks.Length - 1);

            newTile.transform.parent = worldChunks[chunkCoord].transform;

            newTile.AddComponent<SpriteRenderer>();
            if (!backgroundElement)
            {
                newTile.AddComponent<BoxCollider2D>();
                newTile.GetComponent<BoxCollider2D>().size = Vector2.one;
                newTile.tag = "Block";
            }

            int spriteIndex = Random.Range(0, tile.tileSprites.Length);
            newTile.GetComponent<SpriteRenderer>().sprite = tile.tileSprites[0];

            if (tile.inBackground)
            {
                newTile.GetComponent<SpriteRenderer>().sortingOrder = 2;
                newTile.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                newTile.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
            newTile.name = tile.tileSprites[0].name;
            newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);

            worldTiles.Add(newTile.transform.position - (Vector3.one * 0.5f));
            worldTileObjects.Add(newTile);
            worldTileClasses.Add(tile);
        }
    }

    public void CheckTile(TileClass tile, int x, int y)
    {
        if (x >= 0 && x<= worldSize && y >= 0 && y<= worldSize)
        {
            if(!worldTiles.Contains(new Vector2Int(x, y)))
            {
                PlaceTiler(tile, x, y);
            }
            else
            {
                if (worldTileClasses[worldTiles.IndexOf(new Vector2Int(x, y))].inBackground)
                {
                    RemoveTile(x, y);
                }
            }
        }
    }
}
