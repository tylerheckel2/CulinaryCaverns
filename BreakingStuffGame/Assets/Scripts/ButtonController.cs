using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "LevelSelection");
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(sceneName: "StartScreen");
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(sceneName: "LevelSelection");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(sceneName: "Credits");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(sceneName: "Settings");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(sceneName: "LevelSelection");
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene(sceneName: "Tutorial Level");
    }

    public void OpenLevel(int levelIndex)
    {
        string levelName = "Level " + levelIndex;
        SceneManager.LoadScene(levelName);
    }
}
