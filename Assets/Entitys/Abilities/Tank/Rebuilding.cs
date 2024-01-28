using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Tank/Rebuilding")]
public class Rebuilding : AssetSpell
{
    [SerializeField] private int _chanse;
    [SerializeField] private float _heal;

    public override void OnTake()
    {
        var health = Movement.singleton.Health;
        health.OnDamaged += (damage) => health.TakeHeal(_heal);
        health.OnDie += () => health.OnDamaged -= (damage) => health.TakeHeal(_heal);
    }
}
