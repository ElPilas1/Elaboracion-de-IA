using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Updatetext : MonoBehaviour
{
    public GameManager.GameManagerVariables variables; //actualiza el texto a la variable de GameManager que se indiquemos.
    private TMP_Text Textcomponent;
    private int auxScore = 0;  // score auxiliar

    void Start()
    {
        Textcomponent = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (variables)
        {
            case GameManager.GameManagerVariables.SCORE:
                int currentScore = GameManager.instance.GetScore(); // llama al score actual del gameManager
                if (auxScore != currentScore)
                {
                    StartCoroutine(FadeOut());
                    auxScore = currentScore;
                }
                break;
            default:
                break;
        }
    }

    IEnumerator FadeOut()
    {
        Color color = Textcomponent.color; // guarda el color del texto
        for (float alpha = 1.0f; alpha >= 0; alpha -= 0.01f) // en cada vuelta del for el color del alfa disminuye
        {
            color.a = alpha;
            Textcomponent.color = color;
            yield return  null;
        }
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        Textcomponent.text = "Score " + GameManager.instance.GetScore(); // puntuacion se actualiza al comenzar el fade in
        Color color = Textcomponent.color;
        for (float alpha = 0.0f; alpha <= 1; alpha += 0.01f)
        {
            color.a = alpha;
            Textcomponent.color = color;
            yield return null;
        }
    }
}


