using System;
using System.Threading.Tasks;
using UnityEngine;

public class RangeDamage : MonoBehaviour
{
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _delay;
    private bool _canShoot = true;

    public async void Attack()
    {
        if (!_canShoot) return;
        _bullet.Create(transform.position);
        _canShoot = false;
        await Task.Delay(TimeSpan.FromSeconds(_delay));
        _canShoot = true;
    }
}
