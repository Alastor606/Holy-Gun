using System;
using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(SpriteRenderer))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField, Range(0.01f, 5)] private float _coolingDown;
    [SerializeField] private float _attackRadius;
    private SpriteRenderer _sprite;
    private Transform _target = null;
    private bool _isTargetFounded = false;
    private bool _canShooting = true;
    private Bullet _currentBullet;

    private void Start()
    {
        _currentBullet = _bullet;
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Shooting();
        FindTarget();
        RotateTowardsTarget();
    }

    private void FindTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _attackRadius);

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<EnemyHealth>())
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.gameObject;
                }
            }
        }
        _target = closestEnemy?.transform;
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

    private async void Shooting()
    {
        if (!_isTargetFounded || !_canShooting) return;
        _canShooting = false;
        await Task.Delay(TimeSpan.FromSeconds(_coolingDown));
        if (this == null) return;
        var bullet = Instantiate(_currentBullet, transform.position, transform.rotation);
        bullet.OnDamaged += LifeSteal;
        _canShooting = true;
    }

    private void LifeSteal(float dealedDamage)
    {
        var health = GetComponentInParent<PlayerHealth>();
        health?.TakeHeal(dealedDamage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}