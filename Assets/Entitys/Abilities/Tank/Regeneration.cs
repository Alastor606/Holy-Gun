using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Tank/Regen")]
public class Regeneration : AssetSpell
{
    [SerializeField] private float _regen;
    public override void OnTake() =>
        Game.Health.Regen += _regen;
    
}
