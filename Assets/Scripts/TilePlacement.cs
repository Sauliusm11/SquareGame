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
    bool overUI = false;
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
        //Debug.Log(eventData.pointerPressRaycast.worldPosition);
        //PlaceTile(eventData.pointerPressRaycast.worldPosition);
        //Vector3Int cellPosition = tilemap.WorldToCell(eventData.pointerPressRaycast.worldPosition);
        //Tile tile = selectionHandler.GetTileFromSelection(manager.GetSelectedSquare());
        //tilemap.SetTile(cellPosition, tile);
        //Debug.Log(cellPosition);
        overUI = false;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        for (int index = 0; index < raycastResults.Count; index++)
        {
            RaycastResult curRaysastResult = raycastResults[index];
            if (curRaysastResult.gameObject.layer == 5)//5 is UI value
            {
                overUI = true;
                Debug.Log("YES");
                break;
            }
        }
        if(!overUI)
            PlaceTile(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }
    public void PlaceTile(Vector3 position)
    {
        overUI = false;
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        for (int index = 0; index < raycastResults.Count; index++)
        {
            RaycastResult curRaysastResult = raycastResults[index];
            if (curRaysastResult.gameObject.layer == 5)//5 is UI value
            {
                overUI = true;
                Debug.Log("YES");
                break;
            }
        }
        if (!overUI)
        { 
            Vector3Int cellPosition = tilemap.WorldToCell(position);
            Tile tile = selectionHandler.GetTileFromSelection(manager.GetSelectedSquare());
            tilemap.SetTile(cellPosition, tile);
            //Debug.Log(cellPosition);
        }
    }
    private void OnMouseDrag()
    {
        PlaceTile(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
