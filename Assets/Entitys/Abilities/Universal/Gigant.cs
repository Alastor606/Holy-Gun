using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Gigant")]
public class Gigant : AssetSpell
{
    public override void OnTake()
    {
        Game.Health.MaxHealth = Game.Health.MaxHealth / 100 * 120;
    }
}
