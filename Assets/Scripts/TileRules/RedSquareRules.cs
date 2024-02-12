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
    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize)
    {
        TileBase tile = tiles[x + y * xSize];
        if (tile != null)
        {
            if (tile.name.Contains(Tile.name) || tile.name.Contains("Question"))
                return true;
        }
        return false;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        int x = location.x;
        int currentX = location.x;
        int y = location.y;
        int currentY = location.y;
        int xSize = bounds.x;
        int ySize = bounds.y;
        if (currentY > 0)
        {
            y = currentY - 1;
            x = currentX;
            if (CheckLocation(x, y, tiles, xSize, ySize))
                return true;
        }

        y = currentY;
        x = currentX + 1;
        if (x < xSize && CheckLocation(x, y, tiles, xSize, ySize))
            return true;
        x = currentX - 1;
        if (x > -1 && CheckLocation(x, y, tiles, xSize, ySize))
            return true;

        y = currentY + 1;
        if (y < ySize)
        {
            x = currentX;
            if (CheckLocation(x, y, tiles, xSize, ySize))
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
