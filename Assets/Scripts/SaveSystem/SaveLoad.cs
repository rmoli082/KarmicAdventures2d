using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoad : MonoBehaviour
{
   public static void Save<T>(T objectToSave, string key)
    {
        string path = Application.persistentDataPath + "/saves/";

        Directory.CreateDirectory(path);

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream filestream = new FileStream(path + key + ".txt", FileMode.Create))
        {
            formatter.Serialize(filestream, objectToSave);
        }
    }

    public static T Load<T>(string key)
    {
        string path = Application.persistentDataPath + "/saves/";

        BinaryFormatter formatter = new BinaryFormatter();
        T returnValue = default(T);
        using (FileStream filestream = new FileStream(path + key + ".txt", FileMode.Open))
        {
           returnValue = (T) formatter.Deserialize(filestream);
        }

        return returnValue;
    }

    public static bool SaveExists(string key)
    {
        string path = Application.persistentDataPath + "/saves/" + key + ".txt";
        return File.Exists(path);
    }

    public static void DeleteAllSaveData()
    {
        string path = Application.persistentDataPath + "/saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete();
        Directory.CreateDirectory(path);
    }
}
