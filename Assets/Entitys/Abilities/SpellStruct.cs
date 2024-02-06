using System.Collections.Generic;
using UnityEngine;

public class SpellStruct : MonoBehaviour
{
    public static List<Spell> Melee = new(), Range = new(), Mag = new(), MiniGun = new(), Ninja = new(), Tank = new(), Universal = new();
    public static List<List<Spell>> Spells = new();
    [SerializeField] private List<AssetSpell> _melee, _range, _mag, _minigun, _ninja, _tank, _universal;
    public static SpellTypes CurrentType { get; private set; }

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
    }

    public static void SetCurrentType(SpellTypes T)=> CurrentType = CurrentType == default ? CurrentType = T : CurrentType;
}
 