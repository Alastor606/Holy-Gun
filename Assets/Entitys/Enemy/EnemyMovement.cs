using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Movement.singleton == null)
        {
            Destroy(this.gameObject);
            return;
        }
        var target = Movement.singleton.transform.position;
        Vector2 direction = (target - transform.position).normalized;
        Vector2 velocity = direction * _speed; 
        _rigidbody.velocity = velocity;
    }

    public void Slow(float value)
    {
        if (value < 0) return;
        _speed -= value;
        if (_speed <= 1) _speed = 1.5f;
    }

    public void Accelerate(float value)
    {
        if (value < 0) return;
        _speed += value;
    }
}
