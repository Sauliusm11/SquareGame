using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    GameManager manager;
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
}
