
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _health;

    private void OnEnable() =>
        _health = _maxHealth;

    public void TakeDamage(float damage)
    {
        if (damage < 0) return;
        _health -= damage;
        if(_health < 0)
        {
            _health = 0;
            Destroy(this.gameObject);
        }
    }
}
