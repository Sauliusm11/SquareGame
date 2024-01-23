using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class TilePlacement : MonoBehaviour, IPointerClickHandler
{
    Tilemap tilemap;
    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        tilemap = gameObject.GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(manager.GetSelectedSquare());
        Debug.Log(tilemap.GetTile(tilemap.WorldToCell(eventData.pointerPressRaycast.worldPosition)));
        Debug.Log("Hi");
    }
}
