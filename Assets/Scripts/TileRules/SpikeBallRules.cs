using UnityEngine;
using UnityEngine.Tilemaps;

internal class SpikeBallRules : AbstractTileRule
{
    public bool alreadyChecked;
    public bool upset;
    public SpikeBallRules(Tile tile)
    {
        Tile = tile;
        alreadyChecked = false;
        upset = false;
    }
    public void Reset()
    {
        alreadyChecked = false;
        upset = false;
    }
    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize)
    {
        TileBase tile = tiles[x + y * xSize];
        if (tile != null)
        {
            if (tile.name.Contains("Empty") || tile.name.Contains(Tile.name) || tile.name.Contains("Question"))
                return true;
            else
                return false;
        }
        return true;
    }
    bool FindSpikes(TileBase[] tiles, Vector2Int bounds)
    {
        for (int x = 0; x < bounds.x; x++)
        {
            for (int y = 0; y < bounds.y; y++)
            {
                TileBase tile = tiles[x + y * bounds.x];
                if(tile != null)
                    if(tile.name.Contains("Triangle") || tile.name.Contains("Arrow"))
                    {
                        return true;
                    }
            }
        }
        return false;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        if (!alreadyChecked)
        {
            upset = FindSpikes(tiles, bounds);
        }
        if (!upset)
        {
            return true;
        }
        else
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
            return true;
        }
    }
}