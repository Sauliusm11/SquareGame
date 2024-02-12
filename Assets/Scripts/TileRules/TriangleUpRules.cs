using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

class TriangleUpRules : AbstractTileRule
{

    public TriangleUpRules(Tile tile)
    {
        Tile = tile;
    }
    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize)
    {
        if (tiles[x + y * xSize] != null)
        {
            if (tiles[x + y * xSize].name.Contains("Empty"))
                return false;
            else
                return true;
        }
        //Change this to true to allow placing at the edges
        return true;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        int x = location.x;
        int currentX = location.x;
        int y = location.y;
        int currentY = location.y;
        int xSize = bounds.x;
        int ySize = bounds.y;
        y = currentY + 1;
        if (y < ySize)
        {
            if (!CheckLocation(x, y, tiles, xSize, ySize))
                return false;
        }
        if (currentY > 0)
        {
            y = currentY - 1;
            x = currentX - 1;
            if (x > -1 && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
            x = currentX + 1;
            if (x < xSize && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
        }
        return true;
    }
}

