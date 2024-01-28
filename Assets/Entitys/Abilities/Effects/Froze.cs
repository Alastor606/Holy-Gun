using System.Collections;
using UnityEngine;

namespace Effects
{
    public class Froze
    {
        private int _time;

        public IEnumerator Freeze(EnemyMovement movement)
        {
            var mainSpeed = movement.Speed;
            movement.Slow(movement.Speed * 100 / 40);
            yield return new WaitForSeconds(_time);
            movement.Accelerate(mainSpeed - movement.Speed);
        }

        public Froze(int time) =>
            _time = time;
    }
}
