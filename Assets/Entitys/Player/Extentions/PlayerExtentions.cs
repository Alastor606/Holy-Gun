public static class Game
{
    public static void HealUpPlayer()
    {
        var health = Movement.singleton.Health;
        health.TakeHeal(health.MaxHealth - health.Health);
    }
}
