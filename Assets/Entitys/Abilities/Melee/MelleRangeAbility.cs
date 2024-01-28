using CodeHelper;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/AddRange")]
public class MelleRangeAbility : AssetSpell
{
    [SerializeField] private float _radius;
    public override void OnTake() =>  
        Movement.singleton.GetComponentsInChildren<MeleeWeapon>().AllDo((item) => item.UpgradeRadius(_radius));
}
