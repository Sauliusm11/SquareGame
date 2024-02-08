using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RuleHandler : MonoBehaviour
{
    Tilemap tilemap;
    SelectionHandler selectionHandler;
    List<Tile> Tiles;
    List<AbstractTileRule> rules = new List<AbstractTileRule>();
    //For reseting the already checked bool
    HexagonRules hexagonRules;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GameObject.Find("Grid").GetComponentInChildren<Tilemap>();
        selectionHandler = GameObject.Find("SelectionManager").GetComponent<SelectionHandler>();
        //Load tile list
        if (Tiles == null)
        {
            Tiles = selectionHandler.GetTileList();
        }
        rules.Add(new RedSquareRules(Tiles[1]));
        rules.Add(new TriangleUpRules(Tiles[2]));
        hexagonRules= new HexagonRules(Tiles[3]);
        rules.Add(hexagonRules);
        rules.Add(new SimpleDotRules(Tiles[4]));
        rules.Add(new PillarRules(Tiles[5]));
        rules.Add(new StarRules(Tiles[6]));
        rules.Add(new DiagonalArrowRules(Tiles[7]));
        rules.Add(new CrossRules(Tiles[8]));
        rules.Add(new SpikeBallRules(Tiles[9]));
        rules.Add(new QuestionMarkRules(Tiles[10]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckRules()
    {
        hexagonRules.Reset();
        tilemap.CompressBounds();
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    foreach (AbstractTileRule rule in rules)
                    {
                        if (tile.name.Contains(rule.Tile.name))
                        {
                            if (!rule.ProcessRule(new Vector2Int(x, y), allTiles, new Vector2Int(bounds.size.x, bounds.size.y)))
                            {
                                Debug.Log(false);

                            }
                        }
                    }
                }
            }
        }
        Debug.Log(true);
    }
}
