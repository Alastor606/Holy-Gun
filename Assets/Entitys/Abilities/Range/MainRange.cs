using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/Main")] 
public class MainRange : AssetSpell
{
    [SerializeField] private float _multiplyDistance;
    public override void OnTake()
    {
        foreach (var item in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) item.Additional += Checkrange;
    }

    private void Checkrange(EnemyHealth damageable)
    {
        var dist = Vector2.Distance(Movement.singleton.transform.position, damageable.transform.position);
        damageable.TakeDamage(dist * _multiplyDistance);
        Debug.Log($"Нанесено урона {dist * _multiplyDistance}");
    }
}
