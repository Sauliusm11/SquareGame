using UnityEngine;
using UnityEngine.Tilemaps;

internal class StarRules : AbstractTileRule
{
    public StarRules(Tile tile)
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
            x = currentX - 1;
            y = currentY - 1;
            if (x > -1 && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
            x = currentX;
            if (!CheckLocation(x, y, tiles, xSize, ySize))
                return false;
            x = currentX + 1;
            if (x < xSize && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
        }
        else
        {
            return false;
        }

        y = currentY;
        x = currentX + 1;
        if (x < xSize && !CheckLocation(x, y, tiles, xSize, ySize))
            return false;
        x = currentX - 1;
        if (x > -1 && !CheckLocation(x, y, tiles, xSize, ySize))
            return false;

        y = currentY + 1;
        if (y < ySize)
        {
            if (x > -1 && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
            x = currentX;
            if (!CheckLocation(x, y, tiles, xSize, ySize))
                return false;
            x = currentX + 1;
            if (x < xSize && !CheckLocation(x, y, tiles, xSize, ySize))
                return false;
        }
        else
        {
            return false;
        }
        return true;
    }
}