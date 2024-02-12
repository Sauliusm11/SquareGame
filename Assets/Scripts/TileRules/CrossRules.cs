using UnityEngine;
using UnityEngine.Tilemaps;

internal class CrossRules : AbstractTileRule
{
    public CrossRules(Tile tile)
    {
        Tile = tile;
    }
    int CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize)
    {
        TileBase tile = tiles[x + y * xSize];
        if (tile != null)
        {
            if (tile.name.Contains("Question"))
                return -1;
            if (tile.name.Contains("Empty"))
                return 0;
            else
                return 1;
        }
        //Change this to true to allow placing at the edges
        return 0;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        int x = location.x;
        int currentX = location.x;
        int y = location.y;
        int currentY = location.y;
        int xSize = bounds.x;
        int ySize = bounds.y;
        int[] state = new int[4];
        int emptyCount = 0;
        int fullCount = 0;
        if (currentY > 0)
        {
            y = currentY - 1;
            state[0] = CheckLocation(x, y, tiles, xSize, ySize);

        }

        y = currentY;
        x = currentX + 1;
        if (x < xSize)
        {
            state[1] = CheckLocation(x, y, tiles, xSize, ySize);
        }
        else
        {
            state[1] = 0;
        }   

        x = currentX - 1;
        if (x > -1)
        {
            state[2] = CheckLocation(x, y, tiles, xSize, ySize);
        }
        else
        {
            state[2] = 0;
        }

        y = currentY + 1;
        if (y < ySize)
        {
            x = currentX;
            state[3] = CheckLocation(x, y, tiles, xSize, ySize);
        }
        else
        {
            state[3] = 0;
        }
        for (int i = 0; i < 4; i++)
        {
            if(state[i] == 1)
            {
                fullCount++;
            }
            if(state[i] == 0)
            {
                emptyCount++;
            }
        }
        if(emptyCount != 0 && fullCount != 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}