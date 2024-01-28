using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/ASUpgrade")]
public class ASUpgrade : AssetSpell
{
    [SerializeField, Range(0.1f,1f)] private float _coolingDownValue;
    public override void OnTake()
    {
        foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.UpgradeCoolingDown(_coolingDownValue);
        }
    }
}
