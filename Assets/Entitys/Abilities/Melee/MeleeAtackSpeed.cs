using CodeHelper;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/AttackSpeed")]
public class MeleeAtackSpeed : AssetSpell
{
    [SerializeField] private float _upgrade;
    public override void OnTake() =>
        Movement.singleton.GetComponentsInChildren<MeleeWeapon>().AllDo((item) => item.UpgradeCoolingDown(_upgrade));
    
}
