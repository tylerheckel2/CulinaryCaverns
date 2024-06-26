using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TerrainHandler : MonoBehaviour
{
    [Header("Tile Atlas")]
    public TileAtlas tileAtlas;

    [Header("Trees")]
    public int treeChance = 10;
    public int minTreeHeight = 4;
    public int maxTreeHeight = 6;

    [Header("Generation Settings")]
    public bool generateCaves = true;
    public int worldSize = 100;
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
    public float numOneRarity;
    public float numOneSize;
    public float numTwoRarity;
    public float numTwoSize;
    public Texture2D numOneSpread;
    public Texture2D numTwoSpread;

    private GameObject[] worldChunks;
    private List<Vector2> worldTiles = new List<Vector2>();
    private List<GameObject> worldTileObjects = new List<GameObject>();

    //private void OnValidate()

    private void Start()
    {
        if (caveNoiseTexture == null)
        {
            caveNoiseTexture = new Texture2D(worldSize, worldSize);
            numOneSpread = new Texture2D(worldSize, worldSize);
            numTwoSpread = new Texture2D(worldSize, worldSize);
        }

        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture(caveFreq, surfaceValue, caveNoiseTexture);
        //ores
        GenerateNoiseTexture(numOneRarity, numOneSize, numOneSpread);
        GenerateNoiseTexture(numTwoRarity, numTwoSize, numTwoSpread);
        CreateChunks();
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        for (int x = 0; x < worldSize; x++)
        {
            float height = Mathf.PerlinNoise((x + seed) * terrainFreq, seed * terrainFreq) * heightMultiplier + heightAddition;
            
            for (int y = 0; y < height; y++)
            {
                Sprite tileSprite;
                if (y < height - dirtLayerHeight)
                {
                    if (numOneSpread.GetPixel(x, y).r > 0.5f)
                    {
                        tileSprite = tileAtlas.numOne.tileSprite;
                    }
                    else if (numTwoSpread.GetPixel(x, y).r > 0.5f)
                    {
                        tileSprite = tileAtlas.numTwo.tileSprite;
                    }
                    else
                    {
                        tileSprite = tileAtlas.stone.tileSprite;
                    }
                }
                else if (y < height - 1)
                {
                    tileSprite = tileAtlas.dirt.tileSprite;
                }
                else
                {
                    tileSprite = tileAtlas.grass.tileSprite;
                }

                if (generateCaves)
                {
                    if (caveNoiseTexture.GetPixel(x, y).r > 0.5f)
                    {
                        PlaceTiler(tileSprite, x, y);
                    }
                }
                else  
                {
                    PlaceTiler(tileSprite, x, y);
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
        for (int x=0; x < noiseTexture.width; x++)
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
        }
    }

    public void PlaceTile(Sprite[] tileSprites, int x, int y, bool backgroundElement)
    {
        if (!worldTiles.Contains(new Vector2Int(x, y)) && x >= 0 && x<= worldSize && y >= 0 && y <= worldSize)
        {
            GameObject newTile = new GameObject();

            int chunkCoord = Mathf.RoundToInt(Mathf.Round(x / chunkSize) * chunkSize);
            chunkCoord /= chunkSize;

            newTile.transform.parent = worldChunks[chunkCoord].transform;

            newTile.AddComponent<SpriteRenderer>();
            if (!backgroundElement)
            {
                newTile.AddComponent<BoxCollider2D>();
                newTile.GetComponent<BoxCollider2D>().size = Vector2.one;
                newTile.tag = "Ground";
            }

            int spriteIndex = Random.Range(0, tileSprites.Length);
            newTile.GetComponent<SpriteRenderer>().sprite = tileSprites[spriteIndex];
            newTile.GetComponent<SpriteRenderer>().sortingOrder = -5;

            newTile.name = tileSprites[0].name;
            newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);

            worldTiles.Add(newTile.transform.position - (Vector3.one * 0.5f));
            worldTileObjects.Add(newTile);

        }
    }

    void GenerateTree(int x, int y)
    {
        int treeHeight = Random.Range(minTreeHeight, maxTreeHeight);
        for (int i = 0; i < treeHeight; i++)
        {
            PlaceTiler(tileAtlas.log.tileSprite, x, y + i);
        }

        PlaceTiler(tileAtlas.leaf.tileSprite, x, y + treeHeight);
        PlaceTiler(tileAtlas.leaf.tileSprite, x, y + treeHeight + 1);
        PlaceTiler(tileAtlas.leaf.tileSprite, x, y + treeHeight + 2);

        PlaceTiler(tileAtlas.leaf.tileSprite, x - 1, y + treeHeight);
        PlaceTiler(tileAtlas.leaf.tileSprite, x - 1, y + treeHeight + 1);

        PlaceTiler(tileAtlas.leaf.tileSprite, x + 1, y + treeHeight);
        PlaceTiler(tileAtlas.leaf.tileSprite, x + 1, y + treeHeight + 1);
    }

    public void PlaceTiler(Sprite tileSprite, int x, int y)
    {
        GameObject newTile = new GameObject();

        float chunkCoord = (Mathf.Round(x / chunkSize) * chunkSize);
        chunkCoord /= chunkSize;
        newTile.transform.parent = worldChunks[(int)chunkCoord].transform;

        newTile.AddComponent<SpriteRenderer>();
        newTile.AddComponent<BoxCollider2D>();
        newTile.GetComponent<BoxCollider2D>().size = Vector2.one;
        newTile.tag = "Ground";
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.name = tileSprite.name;
        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);

        worldTiles.Add(newTile.transform.position - (Vector3.one * 0.5f));
    }
}
