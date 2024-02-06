using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Tank/Main")]
public class TankMain : AssetSpell
{
    [SerializeField] private float _backDamageValue;
    public override void OnTake()
    {
        var health = Game.Health;
        health.BackDamagePersent += _backDamageValue;
        health.OnDie += () => health.BackDamagePersent -= _backDamageValue;
    }
}
