using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _weaponHolders;
    [SerializeField] private Weapon _mainWeapon;

    private void Start() => SetWeapon(_mainWeapon);

    public void SetWeapon(Weapon weapon)
    {
        foreach(var weaponHolder in _weaponHolders)
        {
            if (weaponHolder.transform.childCount == 0)
            {
                var weap = Instantiate(weapon, weaponHolder.transform);
                weap.transform.position = weaponHolder.transform.position;
                break;
            }
        }
    }
}
