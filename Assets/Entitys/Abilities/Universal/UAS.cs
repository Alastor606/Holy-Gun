using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Up AS")]
public class UAS : AssetSpell
{
    [SerializeField] private float _percent;
    public override void OnTake()
    {
        foreach(var item in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            item.UpgradeCoolingDown(Movement.singleton.Health.Regen / 100 * _percent);
        }
    }
}
