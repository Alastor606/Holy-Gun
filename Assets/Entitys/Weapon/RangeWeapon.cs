using System;
using UnityEngine;
using System.Threading.Tasks;

public class RangeWeapon : Weapon
{
    [SerializeField] protected BaseBullet _bullet;
    private bool _isTargetFounded = false;
    private bool _canShooting = true;
    private BaseBullet _currentBullet;
    public BaseBullet CurrentBullet { get { return _currentBullet; } set { _currentBullet = value; } }

    private void Start()
    {
        _currentBullet = _bullet;
    }

    private void FixedUpdate()
    {   
        FindTarget();
        RotateTowardsTarget();
        Shoot();
    }

    private void RotateTowardsTarget()
    {
        if (_target != null)
        {
            _isTargetFounded = true;
            Vector2 direction = _target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else _isTargetFounded = false;
    }

    protected async void Shoot()
    {
        if (!_isTargetFounded || !_canShooting) return;
        _canShooting = false;
        await Task.Delay(TimeSpan.FromSeconds(_coolingDown));
        if (this == null) return;
        var bullet = Instantiate(_currentBullet, transform.position, transform.rotation);
        bullet.OnEnemyTouch += Attack;
        _canShooting = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}
