using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> The GameManager is the main controller of the game. It handles the game state and the game flow. </summary>
//SerializedMonoBehaviour to check dictionaries, can be changed back to MonoBehaviour
public class GameManager : MonoBehaviour
{
	public static GameManager instance; //Singleton

	public string sceneName; //name of the scene

	/// <summary> Awake is called when the script instance is being loaded. </summary>
	private void Awake()
	{
		if (instance == null) //If instance is not assigned
		{
			instance = this; //Assign instance to this
		}
		else //else no need for this gameobject!
		{
			Destroy(gameObject); //Destroy this gameobject
		}
			
		sceneName = SceneManager.GetActiveScene().name; //Get the name of the scene
	} 
}


