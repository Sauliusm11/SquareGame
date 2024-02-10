using UnityEngine;
using UnityEngine.Tilemaps;

internal class DiagonalArrowRules : AbstractTileRule
{
    public DiagonalArrowRules(Tile tile)
    {
        Tile = tile;
    }

    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize)
    {
        if (tiles[x + y * xSize] != null)
        {
            if (tiles[x + y * xSize].name.Contains("Empty"))
                return true;
            else
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
        while(x+1 < xSize && y + 1 < ySize)
        {
            x += 1;
            y += 1;
            if(!CheckLocation(x,y,tiles,xSize,ySize))
            {
                Debug.Log(tiles[x + y * xSize]);
                return false;
            }
        }
        x = currentX;
        y = currentY;
        while(x > 0 && y > 0)
        {
            x -= 1;
            y -= 1;
            if(!CheckLocation(x,y,tiles,xSize,ySize))
            {
                Debug.Log(tiles[x + y * xSize]);
                return false;
            }
        }
        return true;
    }
}