using CodeHelper.Mathematics;
using CodeHelper.Unity;
using UnityEngine;

public class Knife : DamageDealler
{
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;
    [SerializeField] private Vector2 _offset;
    private float _time = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth damageable)) DoDamage(damageable);
    }

    private void FixedUpdate()
    {
        if (_time < 1) _time += 0.01f;
        else _time = 0;
        transform.position = MathMoving.MoveByCircle(transform.parent.position.ToV2() + _offset, _radius, _time);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
