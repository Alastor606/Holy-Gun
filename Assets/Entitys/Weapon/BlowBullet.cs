using CodeHelper;
using CodeHelper.Unity;
using System.Collections.Generic;
using UnityEngine;

public class BlowBullet : BaseBullet
{
    [SerializeField] private float _blowRadius;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth damageable))
        {
            OnEnemyTouch?.Invoke(damageable);
            List<Collider> coliders = new();
            Physics.OverlapSphereNonAlloc(transform.position, _blowRadius, coliders.ToArray());
            if (!coliders.IsEmpty())
            {
                foreach (var item in coliders)
                {
                    if (item.TryGetComponent(out EnemyHealth dm))
                    {
                        OnEnemyTouch?.Invoke(dm);
                        dm.PrintName();
                    }
                    else Debug.Log("No found");
                }
            }
                
            
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _blowRadius);
    }
}
