using CodeHelper;
using UnityEngine;

internal class HolyWave : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _damage;

    public void Attack() =>
        Physics.OverlapSphere(transform.position, _radius).AllDo((item) => {
            if (item.TryGetComponent(out EnemyHealth health)) health.TakeDamage(_damage);
        });
        

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    } 
}