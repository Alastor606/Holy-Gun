using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Tank/Additional Armor")]
public class AdditionalArmor : AssetSpell
{
    [SerializeField] private float _additional;
    public override void OnTake()
    {
        var health = Movement.singleton.Health;
        health.Armor += _additional;
        health.OnDie += () => health.Armor -= _additional;
    }
}
