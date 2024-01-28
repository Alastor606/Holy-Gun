using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Melee/Main")]
public class MainMelee : AssetSpell
{
    [SerializeField] private Knife _knife;

    public override void OnTake() =>
        Instantiate(_knife.gameObject, Movement.singleton.transform);
    
}
