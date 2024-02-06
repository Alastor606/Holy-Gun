using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/Main")]
public class MainMiniGun : AssetSpell
{
    [SerializeField] private Turret _turret;
    public override void OnTake()
    {
        var tur = Instantiate(_turret, Movement.singleton.transform.position, Quaternion.identity);
        Game.Health.OnDie += () => Destroy(tur.gameObject);
    }
}
