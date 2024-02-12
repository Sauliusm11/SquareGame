using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RedSquareRules : AbstractTileRule
{

    public RedSquareRules(Tile tile)
    {
        Tile = tile;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        int x = location.x;
        int y = location.y;
        int xSize = bounds.x;
        int ySize = bounds.y;
        if(x > 0 && tiles[x - 1 + y * xSize] != null)
        {
            if(tiles[x - 1 + y * xSize].name.Contains(Tile.name))
                return true;
        }
        if (x < xSize-1 && tiles[x + 1 + y * xSize] != null)
        {
            if(tiles[x + 1 + y * xSize].name.Contains(Tile.name))
                return true;
        }
        if (y > 0 && tiles[x + (y - 1) * xSize] != null)
        {
            if(tiles[x + (y - 1) * xSize].name.Contains(Tile.name))
                return true;
        }
        if (y < ySize-1 && tiles[x + (y + 1) * xSize] != null)
        {
            if (tiles[x + (y + 1) * xSize].name.Contains(Tile.name))
                return true;
        }
        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
