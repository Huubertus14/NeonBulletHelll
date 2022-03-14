using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapLoader : MonoBehaviour
{
	private void Awake()
	{
		SceneManager.sceneLoaded += MenuLoaded;
		SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
	}

	private void MenuLoaded(Scene arg0, LoadSceneMode arg1)
	{
		if(arg0.name.Equals("Menu"))
		{
			SceneManager.sceneLoaded -= MenuLoaded;

			//Do other stuff on initialization

			//Initialize loadingScreen
		}
	}
}
