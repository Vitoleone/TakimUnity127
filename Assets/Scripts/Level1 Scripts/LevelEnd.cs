using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IAnimal player))
        {
            int activeIndex = SceneManager.GetActiveScene().buildIndex;
            if (activeIndex < SceneManager.sceneCountInBuildSettings-1)
            {
                SceneManager.LoadScene(activeIndex + 1);
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
