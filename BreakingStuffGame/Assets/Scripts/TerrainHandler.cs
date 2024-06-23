using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHandler : MonoBehaviour
{
    public int dirtLayerHeight = 5;
    
    public Sprite dirt;
    public Sprite grass;
    public Sprite stone;

    private GameObject[] worldChunks;
    private List<Vector2> worldTiles = new List<Vector2>();
    private List<GameObject> worldTileObjects = new List<GameObject>();

    public bool generateCaves = true;

    public int worldSize = 100;
    public int chunkSize = 16;

    public float surfaceValue = 0.25f;
    public float caveFreq = 0.05f;
    public float terrainFreq = 0.05f;
    public float heightMultiplier = 4f;
    public int heightAddition = 25;

    public float seed;
    public Texture2D noiseTexture;

    private void Start()
    {
        seed = Random.Range(-10000, 10000);
        GenerateNoiseTexture();
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
                    tileSprite = stone;
                }
                else if (y < height - 1)
                {
                    tileSprite = dirt;
                }
                else
                {
                    tileSprite = grass;
                }

                if (generateCaves)
                {
                    if (noiseTexture.GetPixel(x, y).r > surfaceValue)
                    {
                        PlaceTiler(tileSprite, x, y);
                    }
                }
                else  
                {
                    PlaceTiler(tileSprite, x, y);
                }
            }
        }
    }


    public void GenerateNoiseTexture()
    {
        noiseTexture = new Texture2D(worldSize, worldSize);

        for (int x=0; x < noiseTexture.width; x++)
        {
            for (int y = 0; y < noiseTexture.height; y++)
            {
                float v = Mathf.PerlinNoise((x + seed) * caveFreq, (y + seed) * caveFreq);
                noiseTexture.SetPixel(x, y, new Color(v, v, v));

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

    public void PlaceTiler(Sprite tileSprite, float x, float y)
    {
        GameObject newTile = new GameObject();
        newTile.transform.parent = this.transform;
        newTile.AddComponent<SpriteRenderer>();
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprite;
        newTile.name = tileSprite.name;
        newTile.transform.position = new Vector2(x + 0.5f, y + 0.5f);
    }
}
