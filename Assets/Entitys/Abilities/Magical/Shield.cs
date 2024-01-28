using CodeHelper;
using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour, IDamageAble
{
    public float Health => _health;
    float IDamageAble.MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _recoverValue, _timeToHeal, _backDamagePersent;
    private bool _canBeHealed = false;

    private void Start() =>
        _health = _maxHealth;
    
    public void TakeDamage(float damage, EnemyDamage target = null)
    {
        if (damage < 0) return;

        _health.Remove(damage);
        StopCoroutine(CheckDamageTime());
        if (_health - damage <= 0)
        {
            this.gameObject.SetActive(false);
            StartCoroutine(CheckDamageTime());
        }
    }

    public void TakeHeal(float value)
    {
        if (value < 0) return;
        if (_health + value <= _maxHealth) _health.Add(value);
        else _health = _maxHealth;
        _canBeHealed = false;
        this.gameObject.SetActive(true);
    }

    private IEnumerator CheckDamageTime()
    {
        yield return new WaitForSeconds(_timeToHeal);
        _canBeHealed = true;
    }

    private void Update()
    {
        if (!_canBeHealed) return;
        TakeHeal(_recoverValue);
    }
}
