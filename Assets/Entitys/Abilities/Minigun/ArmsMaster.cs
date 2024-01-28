using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/All Hand Master")]
public class ArmsMaster : AssetSpell
{
    private List<float> _originalDamages = new();
    public override void OnTake()
    {
        foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            _originalDamages.Add(weapon.Damage);
            weapon.UpgradeDamage(3 - weapon.CoolingDown);
        }

        Movement.singleton.GetComponent<PlayerHealth>().OnDie += () =>
        {
            var index = 0;
            foreach(var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
            {
                weapon.DegradeDamage(weapon.Damage - _originalDamages[index]);
                index++;
            }
        };
    }
}
