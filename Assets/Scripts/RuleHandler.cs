using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
public class RuleHandler : MonoBehaviour
{

    public TextMeshProUGUI text;
    int counter = 0;
    Tilemap tilemap;
    SelectionHandler selectionHandler;
    List<Tile> Tiles;
    List<AbstractTileRule> rules = new List<AbstractTileRule>();
    //For reseting the already checked bool
    HexagonRules hexagonRules;
    SpikeBallRules spikeRules;
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
        hexagonRules = new HexagonRules(Tiles[3]);
        rules.Add(hexagonRules);
        rules.Add(new SimpleDotRules(Tiles[4]));
        rules.Add(new PillarRules(Tiles[5]));
        rules.Add(new StarRules(Tiles[6]));
        rules.Add(new DiagonalArrowRules(Tiles[7]));
        rules.Add(new CrossRules(Tiles[8]));
        spikeRules = new SpikeBallRules(Tiles[9]);
        rules.Add(spikeRules);
        rules.Add(new QuestionMarkRules(Tiles[10]));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitiateRuleCheck()
    {
        //Debug.Log(CheckRules());
        counter++;
        text.text = CheckRules().ToString()+" "+counter;
    }
    private bool CheckRules()
    {
        hexagonRules.Reset();
        spikeRules.Reset();
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
                                return false;

                            }
                        }
                    }
                }
            }
        }
        return true;
    }

}
