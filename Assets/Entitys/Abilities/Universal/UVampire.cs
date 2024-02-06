using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Vamp")]
public class UVampire : AssetSpell
{
    [SerializeField] private int _percent = 2;
    public override void OnTake()
    {
        foreach (Weapon weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.OnDamaged += Heal;
        }

        Movement.singleton.GetComponent<PlayerHealth>().OnDie += () =>
        {
            foreach (Weapon weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
            {
                weapon.OnDamaged -= Heal;
            }
        };
    }

    private void Heal(float damage) =>
        Game.Health.TakeHeal(damage / 100 * _percent);
    
}
