using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;


public class LevelHandler : MonoBehaviour
{
    class SavedTiles
    {
        public List<int> x = new List<int>();
        public List<int> y = new List<int>();
        public List<string> Name = new List<string>();
    }
    Tilemap tilemap;
    SelectionHandler selectionHandler;
    List<Tile> Tiles;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        selectionHandler = GameObject.Find("SelectionManager").GetComponent<SelectionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTiles()
    {
        //Change to a prompt asking for file name
        string filename = "Save.json";
        string jsonData = File.ReadAllText(Application.dataPath + "/Levels/" + filename);
        SavedTiles savedTiles = JsonUtility.FromJson<SavedTiles>(jsonData);

        //Load tile list
        if (Tiles == null)
        {
           Tiles = selectionHandler.GetTileList();
        }

        //Clear out current level
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                tilemap.SetTile(new Vector3Int(x + bounds.position.x, y + bounds.position.y), null);
            }
        }
        
        //Loading the level
        for (int i = 0; i < savedTiles.x.Count; i++)
        {
            string name = savedTiles.Name[i];
            if (name != "empty")
            {
                foreach (Tile tile in Tiles)
                {
                    if (tile.name.Equals(name))
                    {
                        tilemap.SetTile(new Vector3Int(savedTiles.x[i], savedTiles.y[i]), tile);
                    }
                }  
            }
            else
            {
                tilemap.SetTile(new Vector3Int(savedTiles.x[i], savedTiles.y[i]), null);
            }
        }
    }
    public void SaveTiles()
    {
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        SavedTiles savedTiles = new SavedTiles();
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                savedTiles.x.Add(x + bounds.position.x);
                savedTiles.y.Add(y + bounds.position.y);
                if (tile != null)
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);
                    savedTiles.Name.Add(tile.name);
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                    savedTiles.Name.Add("empty");
                }

            }
        }
        string jsonData = JsonUtility.ToJson(savedTiles);
        //Figure out location and writing
        //Change to a prompt asking for file name
        string filename = "Save.json";
        //Debug.Log(Application.dataPath + "/Levels/" + filename);
        File.WriteAllText(Application.dataPath + "/Levels/" + filename, jsonData);
    }
}
