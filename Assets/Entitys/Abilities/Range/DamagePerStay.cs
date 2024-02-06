using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/StayingDamage")]
public class DamagePerStay : AssetSpell
{
    private List<float> _damages;
    public override void OnTake()
    {
        Movement.singleton.OnStay += StartUpDamage;
        Movement.singleton.OnMove += ResetDamage;
        Game.Health.OnDie += () =>
        {
            Movement.singleton.OnStay -= StartUpDamage;
            Movement.singleton.OnMove -= ResetDamage;
        };
    }

    private async void StartUpDamage()
    {
        foreach (var damage in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) _damages.Add(damage.Damage);

        for (int i = 0; i < 6; i++)
        {
            await Task.Delay(1000);
            foreach (var damage in Movement.singleton.GetComponentsInChildren<RangeWeapon>()) 
            {
                damage.UpgradeDamage(damage.Damage / 100 * 3);
            }
        }
    }

    private void ResetDamage(Vector2 input)
    {
        for (int i = 0; i < _damages.Count; i++)
        {
            Movement.singleton.GetComponentsInChildren<RangeWeapon>()[i].SetDamage(_damages[i]);
        }
        _damages.Clear();
    }
}
