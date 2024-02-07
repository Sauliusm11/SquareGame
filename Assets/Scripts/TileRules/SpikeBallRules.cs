using UnityEngine;
using UnityEngine.Tilemaps;

internal class SpikeBallRules : AbstractTileRule
{
    public SpikeBallRules(Tile tile)
    {
        Tile = tile;
    }

    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        throw new System.NotImplementedException();
    }
}