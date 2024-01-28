using System.Collections;
using UnityEngine;

namespace Effects
{
    public class Fire
    {
        private int _damage, _tickCount;
        
        public IEnumerator DealDamage(EnemyHealth health)
        {
            for(int i = 0; i < _tickCount; i++)
            {
                yield return new WaitForSeconds(1);
                if(health != null)health.TakeDamage(_damage);
            }
        }

        public Fire(int damage, int tickCount)
        {
            _damage = damage;
            _tickCount = tickCount;
        }   
    }
}

