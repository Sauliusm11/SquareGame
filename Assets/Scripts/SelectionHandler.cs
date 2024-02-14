using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.Tilemaps;
using System;

public class SelectionHandler : MonoBehaviour
{
    GameManager manager;
    [SerializeField]
    List<Tile> Tiles;
    [SerializeField]
    List<GameObject> SelectorButtons;

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
    public int GetTileCount(GameManager.Selected selection)
    {
        int count = 0;
        if(selection.ToString().Contains("Empty"))
        { return 1; }
        foreach (GameObject button in SelectorButtons)
        {
            if (button.name.Contains(selection.ToString()))
            {
                string text = button.GetComponentInChildren<TMP_Text>().text;
                int.TryParse(text, out count);
                return count;
            }
        }
        return count;
    }
    public void UpdateTileCount(GameManager.Selected selection, int change)
    {
        int count = 0;
        foreach (GameObject button in SelectorButtons)
        {
            if (button.name.Contains(selection.ToString()))
            {
                TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
                string text = tMP_Text.text;
                int.TryParse(text, out count);
                tMP_Text.text = (count + change).ToString();
            }
        }
    }
    public bool CheckTileCounters()
    {
        int count = 0;
        foreach (GameObject button in SelectorButtons)
        {
            TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
            string text = tMP_Text.text;
            int.TryParse(text, out count);
            if(count > 0)
            {
                return false;
            }
        }
        return true;
    }

    public void LoadTileCounts(List<string> Names, List<int> Numbers)
    {
        for (int i = 0; i < Names.Count; i++)
        {
            GameObject button = SelectorButtons[i];
            SetTileCount(button, Numbers[i]);
        }
    }
    private void SetTileCount(GameObject button, int count)
    {
        TMP_Text tMP_Text = button.GetComponentInChildren<TMP_Text>();
        tMP_Text.text = count.ToString();
    }
    //public int GetSelectedTileCount()
    //{
    //    int count = 0;
    //    GameManager.Selected selection = manager.GetSelectedSquare();
    //    foreach (GameObject button in SelectorButtons)
    //    {
    //        if(button.name.Contains(selection.ToString()))
    //        {
    //            string text = button.GetComponentInChildren<TMP_Text>().text;
    //            int.TryParse(text, out count);
    //            return count;

    //        }
    //    }
    //    return count;
    //}
}
