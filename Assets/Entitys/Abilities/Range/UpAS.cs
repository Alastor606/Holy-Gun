using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/UpAS")]
public class UpAS : AssetSpell
{
    [SerializeField] private float _speedReduction;
    public override void OnTake()
    {
        foreach (var item in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) item.UpgradeCoolingDown(_speedReduction); 
    }
}
