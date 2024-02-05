using CodeHelper;
using System.Collections.Generic;
using UnityEngine;

public class ShopResourses : MonoBehaviour
{
    [SerializeField] private List<AssetShopItem> _items;
    private static List<AssetShopItem> Items;

    private void Awake() =>
        Items = _items;
    
    public static AssetShopItem GetRandomItem() =>
        Items.GetRandom();
    
}
