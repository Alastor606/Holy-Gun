using UnityEngine;

[CreateAssetMenu(menuName = "ShopItem")]
public class AssetShopItem : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public string Description { get; protected set; }
    [field: SerializeField] public ShopTypes Type { get; protected set; }
    [field: SerializeField] public int Cost { get; protected set; }
    [field: SerializeField] public Sprite Icon { get; protected set; }
    [field: SerializeField] public Object Prefab { get; protected set; }
}


public enum ShopTypes
{
    Weapon,
    Item
}