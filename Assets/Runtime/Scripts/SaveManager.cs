using UnityEngine;
using System.IO;
using UTMS.Map;

/// <summary> SaveManager is a class that handles saving and loading of the game. </summary>
public class SaveManager : MonoBehaviour
{
    /// <summary> Save the scene. </summary>
    public void SaveScene()
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves"); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves

        if(!Directory.Exists(path)){
            Directory.CreateDirectory (path); // Create the directory if it doesn't exist
            Debug.Log("Created directory: " + path);
        }

        //Save Map
        MapSerializer.SaveMap(path, MapManager.instance.floorMap, MapManager.instance.floorTiles); //Save floorTiles to file
        MapSerializer.SaveMap(path, MapManager.instance.obstacleMap, MapManager.instance.obstacleTiles); //Save obstacleTiles to file
    }

    /// <summary> Load the scene. </summary>
    public void LoadScene(string sceneName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves"); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves

        if(!Directory.Exists(path)){
            Debug.Log("Directory does not exist: " + path);
            return;
        }

        path = Path.Combine(path, sceneName); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves\SceneName

        //Initialize the mapPath
        path = Path.Combine(path, "Maps"); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves\SceneName\Maps
        
        //Load Map
        foreach (string map in Directory.GetFiles(path))
        {
            string mapName = Path.GetFileNameWithoutExtension(map); //Get the map name without the extension
            switch (mapName)
            {
                case "FloorMap":
                    MapSerializer.LoadMap(mapName, path, MapManager.instance.floorMap, MapManager.instance.floorTiles);
                    break;
                case "ObstacleMap":
                    MapSerializer.LoadMap(mapName, path, MapManager.instance.obstacleMap, MapManager.instance.obstacleTiles);
                    break;
                default:
                    break;
            }
        }   
    }

    /// <summary> Delete the scene. </summary>
    public void DeleteScene(string sceneName)
    {
        string path = Path.Combine(Application.persistentDataPath, "Saves"); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves

        path = Path.Combine(path, sceneName); //path = C:\Users\User\AppData\LocalLow\HumbleRPG\Saves\SceneName

        if(Directory.Exists(path))
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.Delete(true);
        }   
    }
}
