using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/GarantedEvasion")]
public class CostGear : AssetSpell
{
    [SerializeField] private float _speedBuff, _evasionBuff;
    [SerializeField] private int _time;
    private bool _canBuff = true;
    public override void OnTake()
    {
        var health = Movement.singleton.Health;
        health.OnValueChanged += Buff;
        health.OnDie += () => health.OnValueChanged -= Buff;
    }

    private async void Buff(float max, float current)
    {
        if (!_canBuff) return;
        _canBuff = false;
        var player = Movement.singleton;
        player.Accelerate(_speedBuff);
        player.Health.Evasion += _evasionBuff;
        await Task.Delay(1000);
        player.Slow(_speedBuff);
        player.Health.Evasion -= _evasionBuff;
        await Task.Delay(_time);
        _canBuff = true;
    }
}
