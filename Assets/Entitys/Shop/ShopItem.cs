using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Item")]
public class ShopItem : AssetShopItem
{
    [HideInInspector]public ItemTypes Type;
    [HideInInspector, Range(0,100)]public float maxHealth, armor, damage, regen;

    public override void OnBuy()
    {
        var health = Game.Health;
        health.UpgradeMaxHealth(maxHealth < 1 ? 0 : maxHealth);
        health.Armor += armor < 1 ? 0 : armor;
        Game.UpWeapon(damage < 1 ? 0 : damage);
        Game.Health.Regen += regen < 1 ? 0 : regen;
    }
}

public enum ItemTypes
{
    MaxHeal,
    Regen,
    Armor,
    Damage,
    Multiply
}

[CustomEditor(typeof(ShopItem))]
public class ItemInspector : Editor
{
    public override void OnInspectorGUI()
    {
        var defaultColor = GUI.contentColor;
        GUI.contentColor = Color.yellow; 

        EditorGUILayout.LabelField("Shop Cell settings : ", CurrentStyle());
        GUILayout.Space(3);
        
        base.OnInspectorGUI();
        GUI.contentColor = Color.cyan;
        EditorGUILayout.LabelField("Item Type : ", CurrentStyle());
        GUILayout.Space(3);
        var tg = (ShopItem)target;
        ShowProperty(nameof(tg.Type));
        switch (tg.Type)
        {
            case ItemTypes.MaxHeal:
                ShowProperty(nameof(tg.maxHealth));
                break;
            case ItemTypes.Regen:
                ShowProperty(nameof(tg.regen));
                break;
            case ItemTypes.Damage:
                ShowProperty(nameof(tg.damage));
                break;
            case ItemTypes.Armor:
                ShowProperty(nameof(tg.armor));
                break;
            case ItemTypes.Multiply:
                ShowAllProperties(tg);
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void ShowProperty(string name) =>
        EditorGUILayout.PropertyField(serializedObject.FindProperty(name));

    private void ShowAllProperties(ShopItem tg)
    {
        ShowProperty(nameof(tg.maxHealth));
        ShowProperty(nameof(tg.regen));
        ShowProperty(nameof(tg.damage));
        ShowProperty(nameof(tg.armor));
    }
    

    private GUIStyle CurrentStyle()
    {
        GUIStyle style = new(GUI.skin.label);
        style.fontSize = 14;
        style.fontStyle = FontStyle.Bold;
        return style;
    }
}