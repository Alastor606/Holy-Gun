using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/Krytical")]
public class KriticalDamage : AssetSpell
{
    [SerializeField] private float _multiplyDistance;
    public override void OnTake()
    {
        foreach (var item in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) item.Additional += Checkrange;
    }

    private void Checkrange(EnemyHealth damageable)
    {
        var dist = Vector2.Distance(Movement.singleton.transform.position, damageable.transform.position);
        damageable.TakeDamage((10 - dist) * _multiplyDistance);
        Debug.Log($"Нанесено урона {dist}");
    }
}
