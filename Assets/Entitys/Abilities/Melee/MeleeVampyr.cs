using CodeHelper;
using UnityEngine;

[CreateAssetMenu(menuName = ("Spells/Melee/Vamp"))]
public class MeleeVampyr : AssetSpell
{
    [SerializeField] private float _heal = 10;
    public override void OnTake() =>
        Movement.singleton.GetComponentsInChildren<MeleeWeapon>().AllDo((item) => item.Additional += Vamp);
    
    private void Vamp(EnemyHealth health) =>
        Movement.singleton.Health.TakeHeal(_heal);
    
}
