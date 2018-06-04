using UnityEngine;

/*
 * Simple following enemy
 */
public class Thief : EnemyController {
  
  private void Update() {
    if (CanHitPlayer())
      Punch();
    else if (PlayerDistance() < triggerRadius)
      FollowPlayer();
  }

  private void Punch()
  {
    Attack();
  }
}