//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MainMenu : MonoBehaviour {

//	public ServeriKommunikaatio sk;

//	void Start()
//	{
//		sk = GameObject.Find("Main Camera").GetComponent<ServeriKommunikaatio>();

//		Scene currentScene = SceneManager.GetActiveScene();

//		string sceneName = currentScene.name;
		
//	}
	
//	public void PlayGame()
//	{
		
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		
//	}
	
//	public void QuitGame()
//	{
//		Debug.Log("QUIT!");
//		Application.Quit();
//	}

//	public void Valikko()
//	{

//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		
//	}

//	void Update()
//	{
//		Scene currentScene = SceneManager.GetActiveScene();

//		string sceneName = currentScene.name;

//		if (sk.nappipainettu)
//		{
//			PlayGame();
//		}

//		if (sceneName == "Menu" && sk.nappi3painettu)
//		{
//			QuitGame();
//			Debug.Log("QUITTTTTTTT");
//		}

//	}

//}
