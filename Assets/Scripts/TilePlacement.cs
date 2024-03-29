using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TilePlacement : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    Tilemap tilemap;
    GameManager manager;
    SelectionHandler selectionHandler;
    RuleHandler ruleHandler;
    bool devMode = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        selectionHandler = GameObject.Find("SelectionManager").GetComponent<SelectionHandler>();
        ruleHandler = GameObject.Find("RuleHandler").GetComponent<RuleHandler>();
        tilemap = gameObject.GetComponentInChildren<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(manager.GetSelectedSquare() != GameManager.Selected.Camera)
            PlaceTile(eventData.pointerCurrentRaycast.worldPosition);
    }
    public void PlaceTile(Vector3 position)
    {        
        //Build eventData from Input pos;
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        if (!PointerOverUI(eventData))
        {
            Vector3Int cellPosition = tilemap.WorldToCell(position);
            GameManager.Selected selection = manager.GetSelectedSquare();
            Tile tile = selectionHandler.GetTileFromSelection(selection);
            TileBase oldTile = tilemap.GetTile(cellPosition);
            if (oldTile != null && selectionHandler.GetTileCount(selection) > 0 || devMode)
            {
                if(devMode)
                tilemap.SetTile(cellPosition, tile);
                else
                {
                    if (oldTile.name.Contains("Locked"))
                    {
                        return;
                    }
                    GameManager.Selected oldTileType = GameManager.Selected.EmptySquare;
                    foreach (GameManager.Selected selectionType in Enum.GetValues(typeof(GameManager.Selected)))
                    {
                        if (oldTile.name.Contains(selectionType.ToString()))
                        {
                            oldTileType = selectionType;
                        }
                    }
                    if(oldTileType != GameManager.Selected.EmptySquare && oldTileType != GameManager.Selected.EmptySquareLocked)
                    selectionHandler.UpdateTileCount(oldTileType, 1);

                    selectionHandler.UpdateTileCount(selection, -1);
                    tilemap.SetTile(cellPosition, tile);
                    ruleHandler.InitiateRuleCheck();
                }
            }
        }
    }
    bool PointerOverUI(PointerEventData eventData)
    {
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        for (int index = 0; index < raycastResults.Count; index++)
        {
            RaycastResult curRaysastResult = raycastResults[index];
            if (curRaysastResult.gameObject.layer == 5)//5 is UI value
            {
                return true;
            }
        }
        return false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (manager.GetSelectedSquare() != GameManager.Selected.Camera)
            PlaceTile(eventData.pointerCurrentRaycast.worldPosition);
    }
}
