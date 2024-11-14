using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public enum GameManagerVariables { SCORE,TIME,LIFE };
    public List<string> hours;
    private float time;
    private int lifes;

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
        time*=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape)) //si presiono el escape me manda al menú
        {
            SceneManager.LoadScene("Inicio");
        
        }
    }
    public void SetLifes(int value)//da las vidas
    {
        lifes = value;
    }
    public int GetLifes()
    {
        return lifes;
    }

    public List<string> GetHours()
    {
        return hours;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value)//puntos
    {
        score = value;
    }
    public void LoadScene(string sceneName)//carga la escena
    {
        time = 0;
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Cerrar");
        Application.Quit();
    }
    public float GetTime() { return time; } //da el el tiempo

}
