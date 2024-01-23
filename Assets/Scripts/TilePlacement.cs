using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TilePlacement : MonoBehaviour, IPointerClickHandler
{
    Tilemap tilemap;
    GameManager manager;
    SelectionHandler selectionHandler;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        selectionHandler = GameObject.Find("SelectionManager").GetComponent<SelectionHandler>();
        tilemap = gameObject.GetComponentInChildren<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerPressRaycast.worldPosition);
        Vector3Int cellPosition = tilemap.WorldToCell(eventData.pointerPressRaycast.worldPosition);
        Tile tile = selectionHandler.GetTileFromSelection(manager.GetSelectedSquare());
        tilemap.SetTile(cellPosition, tile);
        Debug.Log(cellPosition);
    }
}
