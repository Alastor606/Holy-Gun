using UnityEngine;

public abstract class AssetSpell : ScriptableObject, Spell
{
    public SpellTypes Type => _type;
    public Sprite Image => _image;
    public string Description => _description;
    public string Name => _name;
    [SerializeField] private SpellTypes _type;
    [SerializeField] private Sprite _image;
    [SerializeField] private string _name, _description;

    public abstract void OnTake();

}