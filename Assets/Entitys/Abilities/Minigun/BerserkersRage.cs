using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/Berserk Rage")]
public class BerserkersRage : AssetSpell
{
    [SerializeField] private float _cooldown, _doingTime;
    private bool _onCooldown = false;
    public override void OnTake()
    {
        var health = Movement.singleton.Health;
        health.OnValueChanged += Check;
    }

    private async  void Check(float max, float current)
    {
        if (_onCooldown) return;
        if(max * 100 / 20 <= current)
        {
            var health = Movement.singleton.GetComponent<PlayerHealth>();
            foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>()) weapon.OnDamaged += (damage) => health.TakeHeal(damage / 2);
            await Task.Delay(TimeSpan.FromSeconds(_doingTime));
            Cooldown();
            foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>()) weapon.OnDamaged -= (damage) => health.TakeHeal(damage / 2);
        }
    }

    private async void Cooldown()
    {
        _onCooldown = true;
        await Task.Delay(TimeSpan.FromSeconds(_cooldown));
        _onCooldown = false;
    }
}
