using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
internal class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed, _damage, _destroyTime;
    private Rigidbody2D _rigidbody;
    private void FixedUpdate() => Move();
    protected void Move() => _rigidbody.AddForce(Vector3.forward * _speed);

    private IEnumerator Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(_destroyTime);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerHealth damageable))
        {
            damageable.TakeDamage(_damage);
            Destroy(this.gameObject);
        }
    }

    public void Create(Vector2 pos) =>
        Instantiate(this, pos, Quaternion.LookRotation(Movement.singleton.transform.position));
    
}