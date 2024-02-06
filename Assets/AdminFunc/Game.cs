using UnityEngine;

public static class Game
{
    public static bool Paused { get; private set; }
    public static PlayerHealth Health { get { return Movement.singleton.GetComponent<PlayerHealth>(); } }
    public static void HealUpPlayer()
    {
        var health = Health;
        health.TakeHeal(health.MaxHealth - health.Health);
    }

    public static void Pause()
    {
        Time.timeScale = 0;
        Paused = true;
    }
        
    
    public static void Unpause()
    {
        Time.timeScale = 1;
        Paused = false;
    }
        

    public static Weapon AddWeapon(Object weapon) => Movement.singleton.GetComponent<WeaponHolder>().SetWeapon(weapon);
}
