using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockIcon;
    // Start is called before the first frame update
    public void UnlockLevel()
    {
        playButton.gameObject.SetActive(true);
        lockIcon.SetActive(false);
    }
}
