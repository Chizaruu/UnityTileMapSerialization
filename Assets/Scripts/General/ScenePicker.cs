using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePicker : MonoBehaviour
{
    public SceneData sceneData;
    
    public void SceneChanger()
    {
        sceneData.sceneLoaded = false;

        if(sceneData.scene.name == "Demo")
        {
            SceneManager.LoadScene("Demo2");
        }
        else
        {
            SceneManager.LoadScene("Demo");
        }
    }
}
