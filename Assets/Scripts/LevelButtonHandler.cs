using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButtonHandler : MonoBehaviour
{
    TMP_Text buttonText;
    GameManager manager;
    LevelHandler levelHandler;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        levelHandler = GameObject.Find("LevelHandler").GetComponent<LevelHandler>();
    }

    // Update is called once per frame
    public void Clicked()
    {
        buttonText = transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        int num = 0;
        if (int.TryParse(buttonText.text.ToString(), out num))
        {
            levelHandler.LoadLevel(num);
            manager.SwitchState(GameManager.State.InGame);
        }
        else
        {
            Debug.Log("LEVEL DOES NOT EXSIST?");
        }
    }
}
