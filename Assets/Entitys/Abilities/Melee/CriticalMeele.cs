using CodeHelper;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/Crit")]
public class CriticalMeele : AssetSpell
{
    private bool _isMoving = false;
    private bool _canCheck = true;
    public override void OnTake()
    {
        Movement.singleton.OnMove += (vector) =>
        {
            _isMoving = true;
            CheckCrit();
        };
            Movement.singleton.OnStay += () => _isMoving = false;
    }

    private async void CheckCrit()
    {
        if (!_canCheck) return;
        var timer = 0;
        _canCheck = false;
        while(_isMoving)
        {
            await Task.Delay(1000);
            timer++;
            if(timer >= 5)
            {
                timer = 0;
                Movement.singleton.GetComponentsInChildren<MeleeWeapon>().AllDo((item) =>
                {
                    var chanse = item.KritChanse;
                    var value = item.KritValue;
                    item.KritChanse = 100;
                    item.KritValue = 400;
                    item.OnDamaged += (vl) =>
                    {
                        item.KritValue = value;
                        item.KritChanse = chanse;
                    };
                }); 
                _canCheck = true;
            }
        }
    }
}
