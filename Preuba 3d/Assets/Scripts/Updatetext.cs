using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Updatetext : MonoBehaviour
{

    private TMP_Text text;
    public GameManager.GameManagerVariables variable;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        GameManager.instance.SetLifes(3);
    }
    void Update()
    {
        switch (variable)
        {
            case GameManager.GameManagerVariables.TIME:
                text.text = "Time: " + GameManager.instance.GetTime().ToString("#.##");
                break;
            case GameManager.GameManagerVariables.LIFE:
                text.text = "Lifes: " + GameManager.instance.GetLifes();
                break;
            default:
                break;
        }
    }


}


