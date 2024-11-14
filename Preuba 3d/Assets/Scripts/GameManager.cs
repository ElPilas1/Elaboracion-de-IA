using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public enum GameManagerVariables { SCORE };
    public List<string> hours;
    private float time;

    private int score;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            hours = new List<string>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<string> GetHours()
    {
        return hours;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)
    {
        score = value;
    }
    public void LoadScene(string sceneName)
    {
        time = 0;
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Cerrar");
        Application.Quit();
    }

}
