using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneProfile
{
    public string scene = "";

    public SceneProfile (SceneData sceneData){
        scene = sceneData.scene.name;
    } 
}
