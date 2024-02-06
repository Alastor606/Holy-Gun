using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Tank/Despersion")]
public class Despersion : AssetSpell
{
    [SerializeField] private int _chanse;
    [SerializeField] private float _range, _multiply;
    public override void OnTake()
    {
        var health = Game.Health;
        health.OnDamaged += (damage) =>
        {
            var rand = Random.Range(0, 100);
            if (rand > _chanse) return;

            var colliders = new Collider[20];
            Physics.OverlapSphereNonAlloc(Movement.singleton.transform.position, _range, colliders);
            foreach(Collider collider in colliders)
            {
                if(collider.TryGetComponent(out EnemyHealth health))health.TakeDamage(damage / 100 * _multiply);
            }
        };
    }
}
