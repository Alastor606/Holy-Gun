using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseBullet : MonoBehaviour
{
    public Action<EnemyHealth> OnEnemyTouch;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _destroyTime;
    protected Rigidbody2D _rigidbody;
    public float Speed { get { return _speed; } }

    private void FixedUpdate() => Move();
    protected void Move() => _rigidbody.AddForce(transform.right * _speed);

    private IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(_destroyTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyHealth damageable))
        {
            OnEnemyTouch?.Invoke(damageable);
            Destroy(this.gameObject);
        }
    }
}
