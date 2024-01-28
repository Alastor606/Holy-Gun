using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Action<float> OnDamaged;
    public delegate void DamageAdditional(EnemyHealth health);
    public DamageAdditional Additional;
    [SerializeField] protected float _damage;
    [SerializeField, Range(0.1f, 2f)] protected float _coolingDown;
    [SerializeField] protected float _attackRadius, _kritikalMultiply = 1, _kriticalChanse;
    protected Transform _target = null;
    public float KritValue { get { return _kritikalMultiply; } set { if (value <= 0) return; _kritikalMultiply = value; } }
    public float KritChanse { get { return _kriticalChanse; } set { if (value <= 100) _kritikalMultiply = value; } }
    public float Damage { get { return _damage; } }
    public float CoolingDown { get { return _coolingDown; } }


    public virtual void UpgradeRadius(float value) =>
        _attackRadius += value;
    public virtual void UpgradeDamage(float value) =>
        _damage += value;
    public virtual void SetDamage(float value) =>
        _damage = value;
    public virtual void DegradeDamage(float value) =>
        _damage -= value;

    public virtual void RemoveDamage(float value)
    {
        if (_damage - value > 0) _damage -= value;
    }

    public virtual void UpgradeCoolingDown(float value)
    {
        if (value < 0 || _coolingDown - value < 0.1) return;
        _coolingDown -= value;
    }

    public virtual void DegradeCoolingDown(float value)
    {
        if (value < 0 || _coolingDown + value > 3) return;
        _coolingDown += value;
    }

    
    protected virtual void FindTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out EnemyHealth damageable))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }
        _target = closestEnemy?.transform;
    }

    public virtual void Attack(EnemyHealth damageable)
    {
        if (Additional != null) Additional(damageable);
        OnDamaged?.Invoke(_damage);
        var currentChanse = UnityEngine.Random.Range(0,100);
        if (currentChanse < _kriticalChanse) damageable.TakeDamage(_damage * _kritikalMultiply);
        else damageable.TakeDamage(_damage);
    }
    
}