using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SceneDataSystem
{
    public static void Save (string saveName, string folderName, SceneData sceneData)
    {        
        string path = Path.Combine(Application.persistentDataPath, "Saves");

        if(!Directory.Exists(path)){
            Directory.CreateDirectory (path);
        }

        path = Path.Combine(path, folderName);

        if(!Directory.Exists(path)){
            Directory.CreateDirectory (path);
        }

        path = Path.Combine(path, saveName + ".humble");   
        
        SceneProfile sceneProfile = new SceneProfile(sceneData);
        string saveJson = JsonUtility.ToJson(sceneProfile, true);

        File.WriteAllText(path, saveJson);
    }

    public static SceneProfile Load (string saveName, string folderName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves");
        path = Path.Combine(path, folderName);
        path = Path.Combine(path, saveName + ".humble");

        if (File.Exists(path))
        {
            string loadJson = File.ReadAllText(path);
            
            SceneProfile sceneProfile = JsonUtility.FromJson<SceneProfile>(loadJson);
            
            return sceneProfile;
        } 
        else
        {
            Debug.LogError("Save file not found.");
            return null;
        }
    }

    public static void Delete()
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves");

        DirectoryInfo directory = new DirectoryInfo(path);

        if(Directory.Exists(path)){
            directory.Delete(true);
            Debug.Log("Save files deleted.");
        }
        else
        {
            Debug.LogError("Save files not found.");
        }
    }
}


