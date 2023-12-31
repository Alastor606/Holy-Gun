using UnityEngine;
using System;
using System.Threading.Tasks;
using Unity.VisualScripting;

[RequireComponent (typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public Action<Vector2> OnMove;
    public Action OnSlide;
    public Action OnStay;
    public static Movement singleton { get; private set; }
    [SerializeField] private float _speed;
    [Header("Force Settings")]
    [SerializeField] private int _force;
    [SerializeField, Range(1,15)] private int _cooldown;
    private bool _onCooldown = false;
    private bool _canRunning = true;
    private bool _isSliding = false;
    private Rigidbody2D _rigidbody;
    
    private void Awake() =>
        singleton = this;

    private void Start() =>
        _rigidbody = GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        if (_isSliding) return;
        var horizontal = Input.GetAxis("Horizontal") * _speed;
        var vertical = Input.GetAxis("Vertical") * _speed;

        _rigidbody.velocity = new Vector2(horizontal, vertical);
        if (!_canRunning) return;
        if (_rigidbody.velocity != Vector2.zero) OnMove?.Invoke(_rigidbody.velocity);
        else OnStay?.Invoke();
    }

    private async void Cooldown()
    {
        await Task.Delay(TimeSpan.FromSeconds(_cooldown));
        _onCooldown = false;
    }

    private async void SlideSettings()
    {
        _canRunning = false;
        _onCooldown = true;
        _isSliding = true;
        await Task.Delay(1000);
        _isSliding = false;
    }

    public async void Slide()
    {
        if(_rigidbody.velocity == Vector2.zero || _onCooldown) return;
        
        SlideSettings();
        Cooldown();
        while (_isSliding)
        {
            await Task.Delay(10);
            _rigidbody.velocity = _rigidbody.velocity * _force;
            OnSlide?.Invoke();
        }   
        _canRunning = true;
    }
}
