using CodeHelper;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Magic/Holy stun")]
public class HolyStun : AssetSpell
{
    public override void OnTake() =>
        Movement.singleton.GetComponentsInChildren<Weapon>().AllDo((item) => {
            item.Additional += (value) => new Effects.Stun(1).StunEnemy(value.GetComponent<EnemyMovement>());
        });
}
