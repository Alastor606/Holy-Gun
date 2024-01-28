using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/UpRadius")]
public class UpRange : AssetSpell
{
    [SerializeField] private float _range;
    public override void OnTake()
    {
        foreach (var item in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) item.UpgradeRadius(_range);
    }
}
