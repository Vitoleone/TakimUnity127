using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CheckpointUI : MonoBehaviour
{
   private void Awake()
   {
      UIManager.instance.onReachCheckpoint += CheckpointReached;
   }

   void CheckpointReached()
   {
      UIManager.instance.checkpointText.text = GameManager.instance.lastCheckpoint.name + " Reached";
      UIManager.instance.checkpointText.gameObject.SetActive(true);
      UIManager.instance.checkpointText.transform.DOPunchScale(Vector3.one * 1.2f, 1.5f,2,0).OnComplete(() =>
      {
         UIManager.instance.checkpointText.gameObject.SetActive(false);
      });


   }
}
