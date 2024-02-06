using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class Shopcell : MonoBehaviour
{
    public Action OnBuyed;
    [SerializeField] private TextMeshProUGUI _name, _description, _cost;
    [SerializeField] private Image _icon;
    private int _currentCost;
    private AssetShopItem _item;

    public void Render(AssetShopItem item)
    {
        _name.text = item.name;
        _description.text = item.Description;
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Icon;
        _currentCost = item.Cost;
        _item = item;
    }

    public void OnBuy()
    {
        if (!Movement.singleton.GetComponent<InGameWallet>().TrySpend(_currentCost)) return;
        switch (_item.Type)
        {
            case ShopTypes.Weapon:
                Game.AddWeapon(_item.Prefab);
                break;
            case ShopTypes.Item:
                break;
        }
        OnBuyed?.Invoke();
    }
}