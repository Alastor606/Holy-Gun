using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Main")]
public class UniversalMain : AssetSpell
{
    [SerializeField] private int _percent = 5;
    public override void OnTake()
    {
        foreach(Weapon weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.UpgradeDamage(Movement.singleton.Health.MaxHealth /100 * _percent);
        }
    }
}
