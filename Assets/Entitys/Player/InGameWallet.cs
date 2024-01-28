using CodeHelper;
using CodeHelper.Unity;
using System;
using UnityEngine;

public class InGameWallet : MonoBehaviour
{
    public Action OnLevelUP;
    public Action<int, int> OnValueChanged;
    [Header("Radius : ")]
    [SerializeField] private float _takeRadius;
    [SerializeField] private Vector2 _offset;
    [Header("Settings : "), Space(2)]
    [SerializeField] private int _levelUp;
    [SerializeField] private int _additional;
    private int _souls, _currentSouls = 0;

    public void Add(int value)
    {
        _souls.Add(value);
        OnValueChanged?.Invoke(_souls, _levelUp);
        _currentSouls.Add(value);
        if(_currentSouls >= _levelUp)
        {
            _levelUp.Add(_additional);
            _currentSouls = 0;
            OnLevelUP?.Invoke();
        }
    }

    public bool TrySpend(int value)
    {
        if(_souls - value < 0) return false;
        _souls -= value;
        return true;
    }

    private void Update()
    {  
        var results = Physics2D.OverlapCircleAll(transform.position.ToV2() + _offset, _takeRadius);
        results.AllDo((item) => {
            if (item.TryGetComponent(out Soul soul)) soul.Take(this);
                });
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position.ToV2() + _offset, _takeRadius);
    }
}
