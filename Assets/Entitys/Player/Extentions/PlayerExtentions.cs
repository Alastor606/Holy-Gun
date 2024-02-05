using UnityEngine;

public static class Game
{
    public static void HealUpPlayer()
    {
        var health = Movement.singleton.Health;
        health.TakeHeal(health.MaxHealth - health.Health);
    }

    public static void Pause() =>
        Time.timeScale = 0;
    
    public static void Unpause() =>
        Time.timeScale = 1;
}
