using UnityEngine;
using UnityEngine.Tilemaps;

internal class StarRules : AbstractTileRule
{
    public StarRules(Tile tile)
    {
        Tile = tile;
    }

    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        throw new System.NotImplementedException();
    }
}