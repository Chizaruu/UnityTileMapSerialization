using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneData : ScriptableObject
{
    public Scene scene;

    public bool sceneLoaded;
    public bool active;

    void OnDisable()
    {
        sceneLoaded = false;
        active = false;
    }
}
