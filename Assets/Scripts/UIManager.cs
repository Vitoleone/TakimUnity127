using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;
    public UnityAction onScoreChanged;

    public UIManager()
    {
        if (instance.IsUnityNull())
        {
            instance = this;
        }
    }
}
