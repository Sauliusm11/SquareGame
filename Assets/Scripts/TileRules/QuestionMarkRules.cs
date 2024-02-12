using UnityEngine;
using UnityEngine.Tilemaps;

internal class QuestionMarkRules : AbstractTileRule
{
    public QuestionMarkRules(Tile tile)
    {
        Tile = tile;
    }

    public override bool ProcessRule(Vector2Int location, TileBase[] tiles, Vector2Int bounds)
    {
        return true;
    }
}