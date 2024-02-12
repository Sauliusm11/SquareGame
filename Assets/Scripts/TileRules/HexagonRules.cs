using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

class HexagonRules : AbstractTileRule
{
    public bool alreadyChecked;
    public HexagonRules(Tile tile)
    {
        Tile = tile;
        alreadyChecked = false;
    }

    public void Reset()
    {
        alreadyChecked = false;
    }
    bool CheckLocation(int x, int y, TileBase[] tiles, int xSize, int ySize, int[] visited)
    {
        TileBase tile = tiles[x + y * xSize];
        if (tile != null)
        {
            if (visited[x + y * xSize] != 1 && (tile.name.Contains(Tile.name) || tile.name.Contains("Question")))
                return true;
        }
        return false;
    }
    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        if (alreadyChecked)
        {
            return true;
        }
        //No matter the outcome the check needs to be performed once as either all are connected or not.
        alreadyChecked = true;
        int x = location.x;
        int y = location.y;
        int xSize = bounds.x;
        int ySize = bounds.y;
        int[] Visited = new int[tiles.Length];
        Stack<Vector2Int> locationStack = new Stack<Vector2Int>();
        locationStack.Push(location);
        //BFS to visit all hexagons
        while (locationStack.Count != 0)//If stack is empty there is no more hexagons that can be accessed and search can be finished.
        {
            Vector2Int currentLocation = locationStack.Pop();
            int currentX = currentLocation.x;
            int currentY = currentLocation.y;
            Visited[currentX + currentY * xSize] = 1;
            if (currentY > 0)
            {
                x = currentX - 1;
                y = currentY - 1;
                if (x > -1 && CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
                x = currentX;
                if (CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
                x = currentX + 1;
                if (x < xSize && CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
            }

            y = currentY;
            x = currentX + 1;
            if (x < xSize && CheckLocation(x,y,tiles,xSize,ySize, Visited))
                locationStack.Push(new Vector2Int(x, y));
            x = currentX - 1;
            if (x > -1 && CheckLocation(x,y,tiles,xSize,ySize, Visited))
                locationStack.Push(new Vector2Int(x, y));
            
            y = currentY + 1;
            if (y < ySize)
            {
                if (x > -1 && CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
                x = currentX;
                if (CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
                x = currentX + 1;
                if (x < xSize && CheckLocation(x, y, tiles, xSize, ySize, Visited))
                    locationStack.Push(new Vector2Int(x, y));
            }
        }

        //Check if every hexagon was visited
        for ( x = 0; x < xSize; x++)
        {
            for ( y = 0; y < ySize; y++)
            {
                TileBase tile = tiles[x + y * xSize];
                if (tile != null)
                {
                    if (tile.name.Contains(Tile.name))
                    {
                        if (Visited[x + y * xSize] != 1)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }
}
