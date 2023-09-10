using UnityEngine;

[RequireComponent(typeof(EnemyMovement),typeof(EnemyDamage))]
public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float _speedUpValue;
    [SerializeField] private float _damageUpValue;
    private EnemyMovement _movement;
    private EnemyDamage _damage;
     
    private void UpLevel()
    {
        _movement.Accelerate(_speedUpValue);
        _damage.UpDamage(_damageUpValue);
    }
}
