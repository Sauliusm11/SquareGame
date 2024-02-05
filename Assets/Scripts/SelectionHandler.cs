using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System;

public class SelectionHandler : MonoBehaviour
{
    GameManager manager;
    [SerializeField]
    List<Tile> Tiles;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void SelectSquare()
    {
        string name = EventSystem.current.currentSelectedGameObject.name;
        name = name.Substring(6);
        foreach(GameManager.Selected selection in Enum.GetValues(typeof(GameManager.Selected)))
        {
            if (name.Equals(selection.ToString()))
            {
                manager.SetSelectedSquare(selection);
            }
        }
    }

    public Tile GetTileFromSelection(GameManager.Selected selection)
    {
        foreach (Tile tile in Tiles)
        {
            if(tile.name.Equals(selection.ToString()))
            {
                return tile;
            }
        }
        //Removal
        return null;
    }

    public List<Tile> GetTileList()
    {
        return Tiles;
    }
}
