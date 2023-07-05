using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;
    [Header("Level 1 Attributes")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI checkpointText;
    public UnityAction onScoreChanged;
    public UnityAction onReachCheckpoint;
    [Header("Level 2 Attributes")] 
    public GameObject gameEndPanel;
    public TextMeshProUGUI gameEndText;
    public Button tryagainButton;
    public Button nextLevelButton;
    public Image levelClearedImage;
    public UnityAction onGameEnd;
    public UnityAction onGameStart;
    public GameObject gameStartPanel;

    public UIManager()
    {
        instance = this;
        
    }
}
