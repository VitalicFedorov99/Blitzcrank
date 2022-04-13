using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
  public void Walk();

  public void Say();

  public void Stun();

  public void Attack();

  public void Death();

  public void GoTrap();
}
