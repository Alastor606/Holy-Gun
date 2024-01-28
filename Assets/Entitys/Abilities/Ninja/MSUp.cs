using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Ninja/Upgrade moovespeed")]
public class MSUp : AssetSpell
{
    [SerializeField] private float _additionalSpeed;
    public override void OnTake()
    {
        Movement.singleton.Accelerate(_additionalSpeed);
        Movement.singleton.Health.OnDie += () => Movement.singleton.Slow(_additionalSpeed);
    }
        
    
}
