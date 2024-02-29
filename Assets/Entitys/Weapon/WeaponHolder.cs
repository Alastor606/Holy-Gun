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
    private List<Weapon> _weapons = new();

    private void Start() => SetWeapon(_mainWeapon);

    public Weapon SetWeapon(UnityEngine.Object weapon)
    {
        if (!HasFreeSlots()) return null;
        _weaponHolders.AllDo((w) =>
        {
            if (!w.HasChildren()) w.SetActive(false);
            else w.SetActive(true);
        });
        foreach(var weaponHolder in _weaponHolders)
        {
            if (!weaponHolder.HasChildren())
            {
                GameObject weap = Instantiate(weapon, weaponHolder.transform).GameObject();
                weap.transform.position = weaponHolder.transform.position;
                weaponHolder.SetActive(true);
                _weapons.Add(weap.GetComponent<Weapon>());
                return weap.GetComponent<Weapon>();
            }
        }
        throw new ArgumentException();
    }

    private bool HasFreeSlots()
    {
        int index = 0;
        _weaponHolders.AllDo((w) => index += w.HasChildren() ? 0 : 1);
        return index != 0;
    }

    public void DestroyWeapons()
    {
        _weaponHolders.AllDo((x) => _ = x.HasChildren() ? x.transform.Clear() : default);
        _weapons.Clear();
        SetWeapon(_mainWeapon);
        _weapons.Add(_mainWeapon);
    }

    public void UpgradeAllDamage(float value) => _weapons.AllDo((w) => w.UpgradeDamage(value));
}
