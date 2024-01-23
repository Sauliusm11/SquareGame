using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectionHandler : MonoBehaviour
{
    GameManager manager;
    //Tiles
    #region
    [SerializeField]
    Tile EmptySquare;
    [SerializeField]
    Tile RedSquare;
    [SerializeField]
    Tile TriangleUp;
    [SerializeField]
    Tile Hexagon;
    [SerializeField]
    Tile SimpleDot;
    [SerializeField]
    Tile Pillar;
    [SerializeField]
    Tile Star;
    [SerializeField]
    Tile DiagonalArrowRight;
    [SerializeField]
    Tile Cross;
    [SerializeField]
    Tile SpikeBall;
    [SerializeField]
    Tile QuestionMark;
    [SerializeField]
    Tile EmptySquareLocked;
    [SerializeField]
    Tile RedSquareLocked;
    [SerializeField]
    Tile TriangleUpLocked;
    [SerializeField]
    Tile HexagonLocked;
    [SerializeField]
    Tile SimpleDotLocked;
    [SerializeField]
    Tile PillarLocked;
    [SerializeField]
    Tile StarLocked;
    [SerializeField]
    Tile DiagonalArrowRightLocked;
    [SerializeField]
    Tile CrossLocked;
    [SerializeField]
    Tile SpikeBallLocked;
    [SerializeField]
    Tile QuestionMarkLocked;
    [SerializeField]
    Tile Removal;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void SelectCross()
    {
        manager.SetSelectedSquare(GameManager.Selected.Cross);
    }
    public void SelectCrossLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.CrossLocked);
    }
    public Tile GetTileFromSelection(GameManager.Selected selection)
    {
        switch (selection)
        {
            case GameManager.Selected.Camera:
                //TODO handle camera case
                break;
            case GameManager.Selected.EmptySquare:
                return EmptySquare;
            case GameManager.Selected.RedSquare:
                return RedSquare;
            case GameManager.Selected.TriangleUp:
                return TriangleUp;
            case GameManager.Selected.Hexagon:
                return Hexagon;
            case GameManager.Selected.SimpleDot:
                return SimpleDot;
            case GameManager.Selected.Pillar:
                return Pillar;
            case GameManager.Selected.Star:
                return Star;
            case GameManager.Selected.DiagonalArrowRight:
                return DiagonalArrowRight;
            case GameManager.Selected.Cross:
                return Cross;
            case GameManager.Selected.SpikeBall:
                return SpikeBall;
            case GameManager.Selected.QuestionMark:
                return QuestionMark;
            case GameManager.Selected.EmptySquareLocked:
                return EmptySquareLocked;
            case GameManager.Selected.RedSquareLocked:
                return RedSquareLocked;
            case GameManager.Selected.TriangleUpLocked:
                return TriangleUpLocked;
            case GameManager.Selected.HexagonLocked:
                return HexagonLocked;
            case GameManager.Selected.SimpleDotLocked:
                return SimpleDotLocked;
            case GameManager.Selected.PillarLocked:
                return PillarLocked;
            case GameManager.Selected.StarLocked:
                return StarLocked;
            case GameManager.Selected.DiagonalArrowRightLocked:
                return DiagonalArrowRightLocked;
            case GameManager.Selected.CrossLocked:
                return CrossLocked;
            case GameManager.Selected.SpikeBallLocked:
                return SpikeBallLocked;
            case GameManager.Selected.QuestionMarkLocked:
                return QuestionMarkLocked;
            case GameManager.Selected.Removal:
                return null;
            default:
                break;
        }
        return null;
    }
}
