using System.Collections.Generic;
using UnityEngine;
using CodeHelper.Unity;
using System;
using CodeHelper;
using Unity.VisualScripting;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<GameObject> _weaponHolders;
    [SerializeField] private Weapon _mainWeapon;

    private void Start() => SetWeapon(_mainWeapon);

    public Weapon SetWeapon(UnityEngine.Object weapon)
    {
        if (!HasFreeSlots()) return null;
        foreach(var weaponHolder in _weaponHolders)
        {
            if (!weaponHolder.HasChildren())
            {
                GameObject weap = Instantiate(weapon, weaponHolder.transform).GameObject();
                weap.transform.position = weaponHolder.transform.position;
                return weap.GetComponent<Weapon>();
            }
        }
        throw new ArgumentException();
    }

    public bool HasFreeSlots()
    {
        int index = 0;
        _weaponHolders.AllDo((w) => index += w.HasChildren() ? 0 : 1);
        return index != 0;
    }
}
