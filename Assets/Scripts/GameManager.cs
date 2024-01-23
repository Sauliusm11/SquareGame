using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Use these for selection
    public enum Selected
    {
        Camera, EmptySquare, RedSquare, TriangleUp, Hexagon, SimpleDot, Pillar, Star, DiagonalArrowRight, Cross, SpikeBall, QuestionMark,
        EmptySquareLocked, RedSquareLocked, TriangleUpLocked, HexagonLocked, SimpleDotLocked, PillarLocked,
        StarLocked, DiagonalArrowRightLocked, CrossLocked, SpikeBallLocked, QuestionMarkLocked, Removal
    };
    private static Selected selectedSquare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSelectedSquare(Selected selection)
    {
        selectedSquare = selection;
    }
    public Selected GetSelectedSquare()
    {
        return selectedSquare;
    }
}
