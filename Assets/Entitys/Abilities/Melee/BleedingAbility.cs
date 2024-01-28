using CodeHelper;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/Bleeding")]
public class BleedingAbility : AssetSpell
{
    [SerializeField] private float _bleedingDamage;
    public override void OnTake()
    {
        var player = Movement.singleton;
        player.GetComponentsInChildren<Weapon>().AllDo((item) => { 
            item.Additional += (value) => new Effects.Bleeding(_bleedingDamage).Bleed(value); 
        });
           
        
    }
}
