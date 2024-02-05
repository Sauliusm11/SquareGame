using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;
using TMPro;

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
    [SerializeField]
    GameObject loadLevelName;
    [SerializeField]
    GameObject saveLevelName;
    [SerializeField]
    TMP_InputField loadInput;
    [SerializeField]
    TMP_InputField saveInput;

    // Start is called before the first frame update
    void Start()
    {
        loadLevelName.SetActive(false);
        saveLevelName.SetActive(false);
        tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        selectionHandler = GameObject.Find("SelectionManager").GetComponent<SelectionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTiles()
    {
        string filename = loadInput.text+".json";
        loadLevelName.SetActive(false);
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
                    savedTiles.Name.Add(tile.name);
                }
                else
                {
                    savedTiles.Name.Add("empty");
                }
            }
        }
        string jsonData = JsonUtility.ToJson(savedTiles);
        string filename = saveInput.text + ".json";
        saveLevelName.SetActive(false);
        File.WriteAllText(Application.dataPath + "/Levels/" + filename, jsonData);
    }
    public void StartSave()
    {
        saveLevelName.SetActive(true);
    }
    public void StartLoad()
    {
        loadLevelName.SetActive(true);
    }

    //These are not used outside of buttons because of unclear naming scheme
    public void CancelSave()
    {
        saveLevelName.SetActive(true);
    }
    public void CancelLoad()
    {
        loadLevelName.SetActive(true);
    }
}
