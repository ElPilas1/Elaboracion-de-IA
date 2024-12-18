using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class saveLoadTXT : MonoBehaviour
{
    public string filename = "test.txt";
    List<string> dates = new List<string>();
    public List<string> hours;
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
            if (dates != null)
            {
                foreach (string date in dates)
                {

                    streamWriter.WriteLine(date.ToString());       
                }
                streamWriter.WriteLine(DateTime.Now.ToString("HH,mm,ss"));
            }
            else
            {
                streamWriter.WriteLine(DateTime.Now.ToString("HH,mm,ss"));
            }
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

                    float x = float.Parse(streamReader.ReadLine());   //parsear algo significa pasar de un sritng a otro tipo de dato diferente(char,bool,etc...)//LA X NO VA NO SE SABE PQ
                    float y = float.Parse(streamReader.ReadLine());
                    float z = float.Parse(streamReader.ReadLine());
                    GameManager.instance.SetScore(int.Parse(streamReader.ReadLine()));
                    dates.Add(streamReader.ReadLine());
                    while (!streamReader.EndOfStream)
                    {
                        hours.Add(DateTime.Now.ToString("HH,mm,ss"));
                    }
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

