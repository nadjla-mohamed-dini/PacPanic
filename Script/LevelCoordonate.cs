using System.Diagnostics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Debug = UnityEngine.Debug;


public class LevelCoordonate : MonoBehaviour
{

    public Tilemap tilemap;
    public TileBase pelletTile;
    public TileBase wallTile;
    public TileBase powerPelletTile;
    public TileBase playerSpawnTile;
    public TileBase ghostSpawnTile;

    private int [,] levelGrind;
    private int width = 18;
    private int height = 10;
    // Start is called before the first frame update
    void Start()
    {
        levelGrind = new int[width, height];
        LoadLevelTileMap();
    }
    void LoadLevelTileMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int cell = new Vector3Int(x,y,0);
                TileBase tile = tilemap.GetTile(cell);

                if (tile == wallTile)
                {
                    levelGrind[x,y] = 1;
                    Debug.Log($"Wall at ({x}, {y})");
                } 

                else if (tile == pelletTile)
                {
                    levelGrind[x,y] = 2;
                    Debug.Log($"Pelette at ({x}, {y})");
                } 
                else if (tile == powerPelletTile)
                {
                    levelGrind[x,y] = 3;
                    Debug.Log($"power pelette et ({x}, {y})");
                }
                else if(tile == ghostSpawnTile)
                {
                    levelGrind[x,y] = 4;
                }
                else if (tile == playerSpawnTile)
                    {
                       levelGrind[x,y] = 5; 
                    } 
                else
                {
                    levelGrind[x,y] = 0;
                }
            }
        }
        Debug.Log("Level coordonate into array");

    }

    public int GetCell(int x, int y)
    {
        return levelGrind[x,y];
    }
    public void SetCell (int x, int y, int value)
    {
        levelGrind [x,y] = value;
    }


}
