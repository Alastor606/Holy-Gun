using System;
using UnityEngine;


public abstract class DamageDealler : MonoBehaviour, IDamage
{   
    public float Damage => _damage;
    public float MultipyKritical => _multipyKritical;

    public Action<float> OnDamaged;
    [SerializeField] protected float _damage, _multipyKritical;

    public virtual void DoDamage(EnemyHealth target)
    {
        var critChance = UnityEngine.Random.Range(0, 100);
        if (critChance < 25) target.TakeDamage(_damage * _multipyKritical);
        else target.TakeDamage(_damage);
    }

    public void UpgradeDamage(float value)
    {
        if (value < 0) return;
        _damage += value;
    }
}