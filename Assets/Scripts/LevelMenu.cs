using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    private int currentLevel;
    [SerializeField] LevelButton[] levels;

    private void Awake()
    {
        levels = GetComponentsInChildren<LevelButton>().ToArray();
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        UnlockLevels();
    }

    public void OpenLevel()
    {
        SceneManager.LoadScene("Level"+currentLevel);
    }

    public void UnlockLevels()
    {
        for (int i = 0; i < currentLevel; i++)
        {
            levels[i].UnlockLevel();
        }
        
    }
}
