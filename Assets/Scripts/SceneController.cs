using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Game Manager game object içine eklenecek script. Game Manager child olarak Audio Manageri alacak

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

   

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings-1 < SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("CurrentLevel",SceneManager.GetActiveScene().buildIndex+1);
            MainMenu();
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel",SceneManager.GetActiveScene().buildIndex+1);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    public void TryAgain()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
