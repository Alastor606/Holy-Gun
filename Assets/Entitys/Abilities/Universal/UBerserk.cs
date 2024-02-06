using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Berserk")]
public class UBerserk : AssetSpell
{
    [SerializeField] private float _cooldown, _doingTime, _regen;
    private bool _onCooldown = false;
    public override void OnTake()
    {
        var health = Game.Health;
        health.OnValueChanged += Check;
    }

    private async void Check(float max, float current)
    {
        if (_onCooldown) return;
        if (max * 100 / 30 <= current)
        {
            var health = Game.Health;
            int timer = 0;
            while(timer < _doingTime)
            {
                health.TakeHeal(_regen);
                await Task.Delay(1000);
                timer++;
            }
            Cooldown();
        }
    }

    private async void Cooldown()
    {
        _onCooldown = true;
        await Task.Delay(TimeSpan.FromSeconds(_cooldown));
        _onCooldown = false;
    }
}
