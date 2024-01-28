using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/Repulsion")]
public class Repulsion : AssetSpell
{
    public override void OnTake()
    {
        foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.Additional += (enemy) => enemy.GetComponent<Rigidbody>().AddForce(enemy.transform.position - Movement.singleton.transform.position);
        }

        Movement.singleton.Health.OnDie += () =>
        {
            foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
            {
                weapon.Additional -= (enemy) => enemy.GetComponent<Rigidbody>().AddForce(enemy.transform.position - Movement.singleton.transform.position);
            }
        };
    }
}
