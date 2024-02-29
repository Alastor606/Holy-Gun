using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed;
    protected Rigidbody2D _rigidbody;
    protected bool _isStunned = false;
    public float Speed { get { return _speed; } }

    private void Start() =>
        _rigidbody = GetComponent<Rigidbody2D>(); 
    
    private void Update()
    {
        if (_isStunned) return;
        if (Movement.singleton == null)
        {
            Destroy(this.gameObject);
            return;
        }
        Move();
    }

    protected virtual void Move()
    {
        var target = Movement.singleton.transform.position;
        Vector2 direction = (target - transform.position).normalized;
        _rigidbody.velocity = direction * _speed;
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

    public async void Stun(int time)
    {
        _isStunned = true;
        await Task.Delay(time);
        _isStunned = false;
    }
}
