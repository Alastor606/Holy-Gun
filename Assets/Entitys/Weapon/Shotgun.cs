using CodeHelper.Unity;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class Shotgun : RangeWeapon
{
    [SerializeField] private int _shotAngle;
    protected async override void Shoot()
    {
        if (!_isTargetFounded || !_canShooting) return;
        _canShooting = false;
        await Task.Delay(TimeSpan.FromSeconds(_coolingDown));
        if (this == null) return;
        for(int i = 0; i< 4; i++)
        {
            var bullet = _bullet.Instance(transform.position, transform.rotation);
            bullet.transform.Rotate(0, 0, UnityEngine.Random.Range(-_shotAngle, _shotAngle));
            bullet.OnEnemyTouch += Attack;
        }
        _canShooting = true;
    }
}
