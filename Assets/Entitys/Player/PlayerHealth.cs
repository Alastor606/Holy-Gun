using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Action OnDie;
    [SerializeField]private float _maxHealth;
    private float _health;

    private void OnEnable() =>
        _health = _maxHealth;
 

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        _health -= damage;
        if(_health <= 0)
        {
            _health = 0;
            OnDie?.Invoke();
            this.gameObject.SetActive(false);
        }
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0) return;
        _health += heal;
        if(_health > _maxHealth) _health = _maxHealth;
    }
}
