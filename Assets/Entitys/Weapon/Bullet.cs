using System.Collections;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public Action<float> OnDamaged;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _bossDamageBonus = 1;
    [SerializeField, Range(1, 10)] private float _kriticalValue = 1;
    private Rigidbody2D _rigidbody;

    private void FixedUpdate() => Move();
    private void Move() => _rigidbody.AddForce(transform.right * _speed);

    public void UpgradeDamage(float value)
    {
        if (value < 0) return;
        _damage += value;
    }

    public virtual void DoDamage(EnemyHealth target)
    {
        var critChance = UnityEngine.Random.Range(0, 100);
        if (critChance < 25) target.TakeDamage(_damage * _kriticalValue);
        else target.TakeDamage(_damage);
    }

    private IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(_destroyTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.GetComponent<EnemyHealth>();
        if (damageable)
        {
            if (damageable.TryGetComponent<BossMark>(out BossMark boss))
            {
                damageable.TakeDamage(_damage * _bossDamageBonus);
                Destroy(this.gameObject);
                return;
            }
            damageable.TakeDamage(_damage);
            OnDamaged?.Invoke(_damage);
            Destroy(this.gameObject);
        }
    }
}