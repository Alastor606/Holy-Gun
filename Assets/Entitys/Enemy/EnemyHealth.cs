
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Soul _soul;
    [SerializeField] private float _maxHealth;
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
            Instantiate(_soul, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
