using UnityEngine;

[RequireComponent (typeof(RangeDamage))]
public class RangeEnemy : EnemyMovement
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private RangeDamage _rangeDamage;

    private void OnValidate() => _rangeDamage ??= GetComponent<RangeDamage>();
    private void Update()
    {
        if (_isStunned) return;
        if (Movement.singleton == null)
        {
            Destroy(this.gameObject);
            return;
        }
        Move();
    }

    protected override void Move()
    {
        var target = Movement.singleton.transform.position;
        Vector2 direction = (target - transform.position).normalized;
        if (Vector2.Distance(target, this.transform.position) <= _attackRadius)
        {
            _rigidbody.velocity = Vector2.zero;
            _rangeDamage.Attack();
            return;
        }
        _rigidbody.velocity = direction * _speed;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
#endif
}
