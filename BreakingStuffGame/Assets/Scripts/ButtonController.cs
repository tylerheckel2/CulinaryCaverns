using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneName: "StartScreen");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(sceneName: "Credits");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }
}
