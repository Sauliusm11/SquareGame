using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class AbstractTileRule
{
    public Tile Tile { get; set; }
    //public Tile lockedTile { get; set; }

    public abstract bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds);
    public Tile GetTile()
    {
        return Tile;
    }
    //public Tile GetLockedTile()
    //{
    //    return lockedTile;
    //}
}
