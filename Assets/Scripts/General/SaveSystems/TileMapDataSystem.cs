using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class TileMapDataSystem
{
    public static void Save (string saveName, string folderName, List<WorldTile> saveTiles)
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

        string saveJson = JsonHelper.ToJson(saveTiles.ToArray(), true);

        File.WriteAllText(path, saveJson);

    }

    public static List<WorldTile> Load (string saveName, string folderName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves");
        path = Path.Combine(path, folderName);
        path = Path.Combine(path, saveName + ".humble");

        if (File.Exists(path))
        {
            List<WorldTile> gameTiles = new List<WorldTile>();

            string loadJson = File.ReadAllText(path);
            
            List<WorldTile> loadTiles = JsonHelper.FromJson<WorldTile>(loadJson).ToList<WorldTile>();

            return loadTiles;
        } 
        else
        {
            Debug.LogError("Save file not found.");
            return null;
        }
    }

    public static void Delete(string folderName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves");
        path = Path.Combine(path, folderName);

        DirectoryInfo directory = new DirectoryInfo(path);
        directory.Delete(true);
    }    
}
