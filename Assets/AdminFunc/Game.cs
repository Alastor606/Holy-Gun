using CodeHelper;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static List<Soul> _souls = new();
    private static List<EnemyHealth> _enemys = new();
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

    public static void DestroyWeapons() => Movement.singleton.GetComponent<WeaponHolder>().DestroyWeapons();
    public static void UpWeapon(float value) => Movement.singleton.GetComponent<WeaponHolder>().UpgradeAllDamage(value);
    public static void Reset()
    {
        Movement.singleton.transform.position = Vector3.zero;
        HealUpPlayer();
    }

    public static Object Instance<T>(T orgign, Vector3 pos) where T : Object
    {
        if (orgign is Soul s)
        {
            var soul = Object.Instantiate(s, pos, Quaternion.identity);
            soul.OnTake += (s) => _souls.Remove(s);
            _souls.Add(soul);
            return soul;
        } 
        else if (orgign is EnemyHealth enemy)
        {
            var en = Object.Instantiate(enemy, pos, Quaternion.identity);
            en.OnDie += (e) => _enemys.Remove(e);
            _enemys.Add(en);
            return en;
        }
        return null;
    }

    public static void ClearAll()
    {
        if(_souls.Count > 0)_souls.AllDo((s) => Object.Destroy(s.gameObject));
        if(_enemys.Count > 0)_enemys.AllDo((e) => Object.Destroy(e.gameObject));
        _souls.Clear();
        _enemys.Clear();
    }

    public static void ShowAbilities() => Movement.singleton.GetComponent<AbilityChoise>().Show();
}
