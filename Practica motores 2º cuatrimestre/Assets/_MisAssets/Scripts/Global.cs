using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class Global 
{
    #region SaveLoadData

    public static void SaveData<T>(this T _data, string path)
    {
        Debug.Log("ADP: " + Application.persistentDataPath);
        string completePath = Path.Combine(Application.persistentDataPath, path);
        Debug.Log(completePath);
        string jsonData = JsonUtility.ToJson(_data);

        if (!File.Exists(completePath))
        {
            File.Create(path);
        }

        File.WriteAllText(path, jsonData);

    }

    public static T LoadData<T>(this string path)
    {

        string completePath = Path.Combine(Application.persistentDataPath, path);

        string _jsonData = File.ReadAllText(completePath);

        if (!File.Exists(completePath))
        {
            return default(T);
        }

        T _data = JsonUtility.FromJson<T>(_jsonData);

        return _data;

    }
    #endregion
}
