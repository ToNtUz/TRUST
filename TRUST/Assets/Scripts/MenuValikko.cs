using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuValikko : MonoBehaviour
{

    public void CharacterSelection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("main menuun");
    }

    public void ReturnCharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
        Debug.Log("main menuun");
    }



}
