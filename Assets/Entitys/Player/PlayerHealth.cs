using System;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageAble
{
    public Action<float> OnDamaged;
    public Action<float, float> OnValueChanged;
    public Action OnDie;
    public Action OnEvade;
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float Health => _health;
    [SerializeField]private float _maxHealth, _evasion, _backDamagePersent, _timeToDamage, _armor, _regen;
    private float _health;
    public bool CanBeDamaged = true;
    public float Regen { get { return _regen; } set { _regen = value; } }
    public float Evasion { get { return _evasion; } set { if (value + _evasion > 100 || value <= 0) return; _evasion = value; } }
    public float BackDamagePersent { get {  return _backDamagePersent; } set {  _backDamagePersent = value; } }
    public float Armor { get { return _armor; } set { if(value > 0)_armor = value; } }
    public bool Alive { get; private set; }

    private void OnEnable()
    {
        _health = _maxHealth;
        OnValueChanged?.Invoke(_maxHealth, _health);
        Regenerate();
    }
        
    public async void TakeDamage(float damage, EnemyDamage target = null)
    {
        if (!CanBeDamaged) return;

        CanBeDamaged = false;
        var evaid = UnityEngine.Random.Range(0,100);

        if (damage < 0 || evaid < _evasion)
        {
            OnEvade?.Invoke();
            return;
        }

        float allDamage = 0;
        if (damage - _armor < 1) allDamage = 1;
        else allDamage = damage - _armor;

        _health -= allDamage;
        OnDamaged?.Invoke(damage);
        if (_backDamagePersent > 0)target.GetComponent<EnemyHealth>().TakeDamage(damage * 100 / _backDamagePersent);

        if (_health <= 0)
        {
            _health = 0;
            OnDie?.Invoke();
            this.gameObject.SetActive(false);
        }
        OnValueChanged?.Invoke(_maxHealth, _health);
        await Task.Delay(TimeSpan.FromSeconds(_timeToDamage));
        CanBeDamaged = true;
    }

    public void TakeHeal(float heal)
    {
        if (heal < 0) return;
        _health += heal;
        if(_health > _maxHealth) _health = _maxHealth;
        OnValueChanged?.Invoke(_maxHealth, _health);
    }

    private async void Regenerate()
    {
        while (Alive)
        {
            await Task.Delay(100);
            TakeHeal(_regen);
        }
    }
}
