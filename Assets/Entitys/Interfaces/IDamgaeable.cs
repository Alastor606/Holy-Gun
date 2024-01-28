public interface IDamageAble
{
    public float Health { get; }
    public float MaxHealth { get; set; }
    public void TakeDamage(float damage, EnemyDamage target = null);
    public void TakeHeal(float value);
}
