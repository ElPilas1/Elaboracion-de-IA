using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveLoadTXT : MonoBehaviour
{
    public string filename = "test.txt";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Guardar a la g
            StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + "//" + filename);//el append false guarda el ultimo guardado,el true guarda los cambios.(el appende es en el parentesis poner true o false)

            streamWriter.WriteLine(transform.position.x);
            streamWriter.WriteLine(transform.position.y);
            streamWriter.WriteLine(transform.position.z);
            streamWriter.WriteLine(GameManager.instance.GetScore());
            streamWriter.Close();//Importante cerrarlo si los cambios con permiso de escritura no se guarda.//SIEMPRE HACER EL CLOSE
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            //cargar informacion
            if (File.Exists(filename))//si el archivo no existe que no lo lea
            {
                GetComponent<CharacterController>().enabled = false;
                try
                {
                    StreamReader streamReader = new StreamReader(filename);//el stream reader es para guardar

                    float x = float.Parse(streamReader.ReadLine());   //parsear algo significa pasar de un sritng a otro tipo de dato diferente(char,bool,etc...)
                    float y = float.Parse(streamReader.ReadLine());
                    float z = float.Parse(streamReader.ReadLine());
                    int Score = int.Parse(streamReader.ReadLine());
                    streamReader.Close();

                    transform.position = new Vector3(x, y, z);//establecemos la posicion del gameobject
                }
                catch (System.Exception e) //Comi no guardamos info en ningun servidor,
                                           //guardamos en local,no tenemos control
                                           //sobre los archivos del usuario.Nos aseguramos de que si algo va mal este todo controlado
                {
                    Debug.Log(e.Message);
                }
                GetComponent<CharacterController>().enabled = true;
            }
        }
    }

}

