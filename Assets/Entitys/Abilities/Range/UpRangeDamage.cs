using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/UpDamage")]
public class UpRangeDamage : AssetSpell
{
    [SerializeField] private float _damage;
    public override void OnTake()
    {
        foreach (var item in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) item.UpgradeDamage(_damage);
    }
}
