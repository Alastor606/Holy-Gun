using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class Shopcell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name, _description, _cost;
    [SerializeField] private Image _icon;

    public void Render(AssetShopItem item)
    {
        _name.text = item.name;
        _description.text = item.Description;
        _cost.text = item.Cost.ToString();
        _icon.sprite = item.Icon;
    }
}