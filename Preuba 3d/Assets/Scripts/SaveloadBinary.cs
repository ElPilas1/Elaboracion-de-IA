using System.Collections;
using System.Collections.Generic;
using System.IO;//IO SIGNIFICA INPUT OUTPUT
using UnityEngine;

public class SaveloadBinary : MonoBehaviour
{
    public string filename = "test.Baratto";
    // Start is called before the first frame update
    void Start()
    {
        filename = Application.persistentDataPath + "//" + filename;
    }

    // Update is called once per frame
    void LateUpdate()
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

    void Save()
    {

        BinaryWriter binaryWriter = new BinaryWriter(new FileStream(filename, FileMode.Create));
        binaryWriter.Write(transform.position.x);
        binaryWriter.Write(transform.position.y);
        binaryWriter.Write(transform.position.z);
        binaryWriter.Flush();//para limpiar la caca y el flujo del vater
        binaryWriter.Close();
    }
    void Load()
    {
        if (File.Exists(filename))
        {
            return;
        }
        BinaryReader binaryReader = new BinaryReader(new FileStream(filename, FileMode.Open));//forma de hacerlo mas profesional con el return
        float x = binaryReader.ReadSingle();
        float y = binaryReader.ReadSingle();
        float z = binaryReader.ReadSingle();
        binaryReader.Close();

        transform.position = new Vector3(x, y, z);
    }

}
