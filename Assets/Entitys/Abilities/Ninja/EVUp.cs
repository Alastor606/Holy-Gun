using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Ninja/Upgrade Evasion")]
public class EVUp : AssetSpell
{
    [SerializeField] private float _additionalEvade;

    public override void OnTake()
    {
        var health = Game.Health;
        health.Evasion += _additionalEvade;
        health.OnDie += () => health.Evasion -= _additionalEvade;
    }
       
}
