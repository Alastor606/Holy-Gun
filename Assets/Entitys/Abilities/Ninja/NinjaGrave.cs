using System.Threading.Tasks;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Spells/Ninja/Grave")]
public class NinjaGrave : AssetSpell
{
    [SerializeField] private float _time;
    private bool  _enabled = true;
    public override void OnTake()
    {
        var health = Game.Health;
        health.OnValueChanged += Check;
        health.OnDie += () => health.OnValueChanged -= Check;
    }

    private async void Check(float max, float current)
    {
        if(max /100 * 30 < current && _enabled)
        {
            _enabled = false;
            var acelerate = Movement.singleton.Speed / 100 * 30;
            Movement.singleton.Accelerate(acelerate);
            await Task.Delay(TimeSpan.FromSeconds(_time));
            Movement.singleton.Slow(acelerate);
        }
    }
}
