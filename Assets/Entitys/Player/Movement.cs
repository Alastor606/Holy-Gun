using UnityEngine;
using System;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public Action<Vector2> OnMove;
    public static Movement singleton { get; private set; }
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;
    
    private void Awake() =>
        singleton = this;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }     

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var vertical = Input.GetAxis("Vertical") * _speed;

        _rigidbody.velocity = new Vector2(horizontal, vertical);
        OnMove?.Invoke(_rigidbody.velocity);
    }

}
