using System.Collections.Generic;
using UnityEngine;

public class SpellStruct : MonoBehaviour
{
    public static List<Spell> Melee = new(), Range = new(), Mag = new(), MiniGun = new(), Ninja = new(), Tank = new(), Universal = new();
    public static List<List<Spell>> Spells = new();
    public static List<string> Descriptions = new();
    public static List<string> Names = new();
    [SerializeField] private List<AssetSpell> _melee, _range, _mag, _minigun, _ninja, _tank, _universal;
    [Space, Space]
    [SerializeField] private List<string> _descriptions;
    [Space, Space]
    [SerializeField] private List<string> _names;

    private void Awake()
    {
        Melee.AddRange(_melee);
        Range.AddRange(_range);
        Mag.AddRange(_mag);
        MiniGun.AddRange(_minigun);
        Ninja.AddRange(_ninja);
        Tank.AddRange(_tank);
        Universal.AddRange(_universal);
        Spells.AddRange(new List<List<Spell>> { Melee, Range, Mag, MiniGun, Ninja, Tank, Universal});
        print(Spells[0][0].Name);
        Descriptions = _descriptions;
        Names = _names;
    }
}
 