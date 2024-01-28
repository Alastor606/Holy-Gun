using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Gigant")]
public class Gigant : AssetSpell
{
    public override void OnTake()
    {
        Movement.singleton.Health.MaxHealth = Movement.singleton.Health.MaxHealth / 100 * 120;
    }
}
