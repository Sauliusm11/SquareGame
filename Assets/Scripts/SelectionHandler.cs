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

    public void SelectEmpty()
    {
        manager.SetSelectedSquare(GameManager.Selected.EmptySquare);
    }
    public void SelectEmptyLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.EmptySquareLocked);
    }
    public void SelectRedSquare()
    {
        manager.SetSelectedSquare(GameManager.Selected.RedSquare);
    }
    public void SelectRedSquareLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.RedSquareLocked);
    }
    public void SelectTriangleUp()
    {
        manager.SetSelectedSquare(GameManager.Selected.TriangleUp);
    }
    public void SelectTriangleUpLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.TriangleUpLocked);
    }
    public void SelectHexagon()
    { 
        manager.SetSelectedSquare(GameManager.Selected.Hexagon);
    }
    public void SelectHexagonLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.HexagonLocked);
    }
    public void SelectSimpleDot()
    {
        manager.SetSelectedSquare(GameManager.Selected.SimpleDot);
    }
    public void SelectSimpleDotLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.SimpleDotLocked);
    }
    public void SelectPillar()
    {
        manager.SetSelectedSquare(GameManager.Selected.Pillar);
    }
    public void SelectPillarLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.PillarLocked);
    }
    public void SelectStar()
    {
        manager.SetSelectedSquare(GameManager.Selected.Star);
    }
    public void SelectStarLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.StarLocked);
    }
    public void SelectDiagonalArrowRight()
    {
        manager.SetSelectedSquare(GameManager.Selected.DiagonalArrowRight);
    }
    public void SelectDiagonalArrowRightLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.DiagonalArrowRightLocked);
    }
    public void SelectCross()
    {
        manager.SetSelectedSquare(GameManager.Selected.Cross);
    }
    public void SelectCrossLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.CrossLocked);
    }
    public void SelectSpikeBall()
    {
        manager.SetSelectedSquare(GameManager.Selected.SpikeBall);
    }
    public void SelectSpikeBallLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.SpikeBallLocked);
    }
    public void SelectQuestionMark()
    {
        manager.SetSelectedSquare(GameManager.Selected.QuestionMark);
    }
    public void SelectQuestionMarkLocked()
    {
        manager.SetSelectedSquare(GameManager.Selected.QuestionMarkLocked);
    }
    public void SelectRemoval()
    {
        manager.SetSelectedSquare(GameManager.Selected.Removal);
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
