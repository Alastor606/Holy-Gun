using UnityEngine;

public interface Spell
{
    public SpellTypes Type { get;}
    public Sprite Image { get;}
    public string Description { get; }
    public string Name { get;}
    public abstract void OnTake();
}
