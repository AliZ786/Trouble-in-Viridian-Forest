using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public static void PlayGame()
    {
       SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void StoryMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene(3);
        



    }

}
