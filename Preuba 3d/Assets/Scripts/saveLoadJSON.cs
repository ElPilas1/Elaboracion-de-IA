using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

    [System.Serializable]
struct PlayerData
{
    public Vector3 position;//un objeto que es capaz de covnertirse en un archivo y ademas el contrario tambien se denomina objeto seriarizable
    public int score;
}
public class saveLoadJSON : MonoBehaviour
{
    public string filename = "test.json";
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.persistentDataPath + '\\' + filename;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Save();
        }

       else if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }




    }
    private void Save()
    {
        StreamWriter streamWriter = new StreamWriter(filename);
    
        PlayerData playerData = new PlayerData();
        playerData.position=transform.position;
        playerData.score = GameManager.instance.GetScore();
        string json=JsonUtility.ToJson(playerData);
        streamWriter.WriteLine(json);

      streamWriter.Close();
    }
     
    private void Load()
    {
        GetComponent<CharacterController>().enabled = false;

        if (File.Exists(filename))
        {
            try 
            { 
            StreamReader streamReader= new StreamReader(filename);

            PlayerData data = JsonUtility.FromJson<PlayerData>(streamReader.ReadToEnd());
            
            streamReader.Close();
            
            transform.position = data.position;
            GameManager.instance.SetScore(data.score);
            }

            catch(System.Exception e)
            {
                Debug.Log(e.Message);
            }
           
           }
        
        
        GetComponent<CharacterController>().enabled = true;
    }







}
