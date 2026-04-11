using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseMenu;
    public GameObject gameCanvas;

    void Start()
    {
        pauseMenu.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;

        if (paused)
        {
            pauseMenu.SetActive(true);
            gameCanvas.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            gameCanvas.SetActive(true);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadSceneAsync("Title");
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
