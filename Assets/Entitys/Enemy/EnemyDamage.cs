using System.Threading.Tasks;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageAble health)) health.TakeDamage(_damage);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageAble health)) DelegateDamage(health);
    }

    private async void DelegateDamage(IDamageAble health)
    {
        if (!_canDamage) return;
        _canDamage = false;
        await Task.Delay(1500);
        var hp = (PlayerHealth)health;
        hp.TakeDamage(_damage, this);
        _canDamage = true;
    }

    public void UpDamage(float value)
    {
        if(value <0) return;
        _damage += value;
    }
}
