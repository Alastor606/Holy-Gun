using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Action<EnemyHealth> OnDie;
    [SerializeField] private Soul _soul;
    [SerializeField] private float _maxHealth;
    [SerializeField] private int _soulsCount;
    private float _health;
    public float CurrentHealth { get { return _health; } }

    private void OnEnable() =>
        _health = _maxHealth;

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        _health -= damage;
        if(_health < 0)
        {
            _health = 0;
            for(int i = 0; i< _soulsCount; i++)Game.Instance(_soul, transform.position);
            OnDie?.Invoke(this);
            Destroy(this.gameObject);
        }
    }
}
