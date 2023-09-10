using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth health)) health.TakeDamage(_damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth health)) DelegateDamage(health);
    }

    private async void DelegateDamage(PlayerHealth health)
    {
        if (!_canDamage) return;
        _canDamage = false;
        await Task.Delay(1500);
        health.TakeDamage(_damage);
        _canDamage = true;
    }

    public void UpDamage(float value)
    {
        if(value <0) return;
        _damage += value;
    }
}
