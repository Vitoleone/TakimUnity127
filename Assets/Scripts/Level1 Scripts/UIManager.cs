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
    public TextMeshProUGUI checkpointText;
    public UnityAction onScoreChanged;
    public UnityAction onReachCheckpoint;

    public UIManager()
    {
        if (instance.IsUnityNull())
        {
            instance = this;
        }
    }
}
