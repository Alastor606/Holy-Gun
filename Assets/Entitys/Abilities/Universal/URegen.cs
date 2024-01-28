using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Regen")]
public class URegen : AssetSpell
{
    [SerializeField] private float _regen;
    public override void OnTake()
    {
        Movement.singleton.Health.Regen += _regen;
    }

}
