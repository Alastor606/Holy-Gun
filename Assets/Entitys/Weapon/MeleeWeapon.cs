using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private float _flySpeed;
    private void Update()
    {
        FindTarget();
    }

    public override void Attack(EnemyHealth damageable)
    {
        if (_target == null) return;
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _flySpeed);
        base.Attack(damageable);
    }
}
