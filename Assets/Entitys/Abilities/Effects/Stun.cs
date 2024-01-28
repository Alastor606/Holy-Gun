using UnityEngine;

namespace Effects
{
    public class Stun : MonoBehaviour
    {
        private int _time;

        public void StunEnemy(EnemyMovement move)
        {
            var rand = Random.Range(0, 100);
            if (rand > 10) return;
            move.Stun(_time);
        }
            
        
        public Stun(int time) =>
            _time = time;
    }
}

