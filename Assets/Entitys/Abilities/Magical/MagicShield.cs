using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Magic/ Shield")]
public class MagicShield : AssetSpell
{
    [SerializeField] private Shield _shield;
    public override void OnTake()
    {
        var shield = Instantiate(_shield, Movement.singleton.transform.position, Quaternion.identity);
        shield.transform.parent = Movement.singleton.transform;
    }
}
