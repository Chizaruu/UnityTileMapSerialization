using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{

    public Tilemap floorMap;
    public Tilemap obstacleMap;

    public SceneData sceneData;

    public GameTiles gameTiles;
    SceneProfile sceneProfile;

    void Awake()
    {
        sceneData.scene = SceneManager.GetActiveScene();

        sceneProfile = SceneDataSystem.Load("sceneData", "Scene");
    }

    void Start()
    {
        if(sceneProfile != null)
        {
            if(sceneData.scene.name == sceneProfile.scene && !sceneData.active ||sceneData.sceneLoaded)
            {
                if(!sceneData.active)
                {
                    sceneData.active = true;
                }
                Load();
            }
        }
    }

    public void Save()
    {
        SceneDataSystem.Save("sceneData", "Scene", sceneData);
        gameTiles.GetWorldTiles(floorMap, true);
        gameTiles.GetWorldTiles(obstacleMap, true);
    }

    public void Load()
    {
        sceneProfile = SceneDataSystem.Load("sceneData", "Scene");
        if(sceneProfile != null)
        {
            sceneData.sceneLoaded = true;
            LoadScene();
        }
    }

    public void LoadScene()
    {
        if(sceneData.scene.name == sceneProfile.scene && !sceneData.active || sceneData.scene.name == sceneProfile.scene && sceneData.active)
        { 
            sceneData.sceneLoaded = true;

            gameTiles.LoadWorldTiles();
        }
        else if(sceneData.scene.name != sceneProfile.scene && sceneData.sceneLoaded)
        {
            sceneData.sceneLoaded = true;

            SceneManager.LoadScene(sceneProfile.scene);
        }  
    }

    public void Delete()
    {
        SceneDataSystem.Delete();
    }
}