using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimal
{
   public void Move();
   public void Die();
   public void GetScore(int value);
}
