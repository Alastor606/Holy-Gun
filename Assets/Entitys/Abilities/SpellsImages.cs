using System.Collections.Generic;
using UnityEngine;

public class SpellsImages : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites;
    public static List<Sprite> Sprites { get;private set; }

    private void Awake() =>
        Sprites = _sprites;

}

public enum SpellTypes
{
    Melee,
    Range,
    Magical,
    AttackSpeed,
    Armor,
    HP,
    Ninja
}