﻿using UnityEngine;
using UnityEngine.Tilemaps;

internal class PillarRules : AbstractTileRule
{
    public PillarRules(Tile tile)
    {
        Tile = tile;
    }
    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize)
    {
        if (tiles[x + y * xSize] != null)
        {
            return false;
        }
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
        if (currentY > 0)
        {
            y = currentY - 1;
            if (CheckLocation(x, y, tiles, xSize))
                return true;
        }
        else
        {
            return true;
        }

        y = currentY;
        if(currentX == 0 || currentX + 1 >= xSize)//xSize is size of array, +1 would be out of array
        {
            return true;
        }
        x = currentX + 1;
        if (x < xSize && CheckLocation(x, y, tiles, xSize))
            return true;
        x = currentX - 1;
        if (x > -1 && CheckLocation(x, y, tiles, xSize))
            return true;

        y = currentY + 1;
        if (y < ySize)
        {
            x = currentX;
            if (CheckLocation(x, y, tiles, xSize))
                return true;
        }
        else
        {
            return true;
        }
        return false;
    }
}