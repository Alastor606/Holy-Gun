using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Weapon")]
public class ShopWeapon : AssetShopItem
{
    [SerializeField] private Weapon _weapon;
    public override void OnBuy() =>
        Game.AddWeapon(_weapon);
    
}
