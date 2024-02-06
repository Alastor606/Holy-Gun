using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Ninja/Main")] 
public class NinjaMain : AssetSpell
{
    [SerializeField] private float _evasion;
    public override void OnTake()
    {
        Game.Health.Evasion += _evasion;
    }
}
