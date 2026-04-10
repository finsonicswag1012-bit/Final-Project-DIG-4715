using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameplayPrototype");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

    public void Controls()
    {
        SceneManager.LoadSceneAsync("Controls");
    }

     public void Lore()
    {
        SceneManager.LoadSceneAsync("Lore");
    }

    public void BacktoMain()
    {
        SceneManager.LoadSceneAsync(0);
    }

   


    
}