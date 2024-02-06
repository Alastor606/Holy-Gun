using CodeHelper;
using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/Grave")]
public class MeleeGrave : AssetSpell
{
    [SerializeField] private GameObject _knifes;
    [SerializeField] private float _cooldown;
    private bool _onCooldown = false;
    public override void OnTake()
    {
        Game.Health.OnDie += () => _onCooldown = false;
        Game.Health.OnValueChanged += CheckGrave;
    }

    private void CheckGrave(float max, float current)
    {
        if (max.Percent(30) > current || _onCooldown) return;
        Destroy(Instantiate(_knifes, Movement.singleton.transform.position, Quaternion.identity), 5);
        Cooldown();
    }

    private async void Cooldown()
    {
        await Task.Delay(TimeSpan.FromSeconds(_cooldown));
        _onCooldown = false;
    }
}
