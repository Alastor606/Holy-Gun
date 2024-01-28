using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Ninja/Main")] 
public class NinjaMain : AssetSpell
{
    [SerializeField] private float _evasion;
    public override void OnTake()
    {
        Movement.singleton.Health.Evasion += _evasion;
    }
}
