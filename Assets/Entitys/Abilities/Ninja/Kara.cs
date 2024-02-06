using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Ninja/Evade + damage")]
public class Kara : AssetSpell
{
    [SerializeField] private float _upDamageTime, _additionalDamage;
    public override void OnTake()
    {
        var health = Game.Health;
        health.OnEvade += Up;
        health.OnDie += () => health.OnEvade -= Up;
    }
        
    private async void Up()
    {
        foreach(var item in Movement.singleton.GetComponentsInChildren<Weapon>()) item.UpgradeDamage(_additionalDamage);
        await Task.Delay(TimeSpan.FromSeconds(_upDamageTime));
        foreach (var item in Movement.singleton.GetComponentsInChildren<Weapon>()) item.RemoveDamage(_additionalDamage);
    }
}
