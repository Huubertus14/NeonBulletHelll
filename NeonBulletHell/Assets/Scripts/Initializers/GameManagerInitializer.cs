using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerInitializer : MonoBehaviour
{
	[RuntimeInitializeOnLoadMethod]
	private static void OnFirstSceneLoaded()
	{
		GameObject g = new GameObject("GameManager", typeof(GameManager));
		DontDestroyOnLoad(g);
		g.hideFlags = HideFlags.HideInHierarchy;
	}
}
