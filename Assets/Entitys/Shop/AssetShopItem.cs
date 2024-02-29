using UnityEngine;

public class AssetShopItem : ScriptableObject
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public string Description { get; protected set; }
    [field: SerializeField] public int Cost { get; protected set; }
    [field: SerializeField] public Sprite Icon { get; protected set; }

    public virtual void OnBuy()
    {

    }
}

