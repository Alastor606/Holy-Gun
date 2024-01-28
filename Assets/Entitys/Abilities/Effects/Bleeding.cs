using System.Collections;
using UnityEngine;

namespace Effects
{
    public class Bleeding
    {
        private float _damage;

        public IEnumerator Bleed(EnemyHealth enemy)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.3f);
                enemy?.TakeDamage(_damage);
            }
        }

        public Bleeding(float damage) =>
            _damage = damage;
        
    }
}

