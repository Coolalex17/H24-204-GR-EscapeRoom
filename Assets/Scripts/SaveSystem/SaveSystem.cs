using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGame (string saveFileName, object data)
    {
        var json = JsonUtility.ToJson (data);
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.WriteAllText(path, json);

            Debug.Log($"reussir de sauver le jeu a {path}.");
        }
        catch (System.Exception ex) 
        {
            Debug.Log(ex);
        }  
    }


    public static T LoadGame<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System .Exception ex) 
        {
            Debug.Log(ex);

            return default(T);
        }
    }

    public static void DeleteSaveFile (string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
        }
        catch (System.Exception ex) 
        {
            Debug.Log(ex);
        }
    }
}
