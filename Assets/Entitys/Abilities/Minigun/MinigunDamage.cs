using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Minigun/Locator")]
public class MinigunDamage : AssetSpell
{
    [SerializeField] private float _asUpgradeValue, _range;
    private bool _canWork = false, _isSpeedUped = false;
    public async override void OnTake()
    {
        _canWork = true;
        while (_canWork)
        {
            await Task.Delay(300);
            int counter = 0;
            Collider[] _colliders = new Collider[10];
            Physics.OverlapSphereNonAlloc(Movement.singleton.transform.position, _range, _colliders);
            foreach (Collider collider in _colliders)
            {
                if (collider.TryGetComponent(out EnemyHealth enemy))
                {
                    UpSpeed();
                    counter++;
                }
            }
            if (counter == 0) SetDefaultSpeed();
        }
    }

    private void UpSpeed()
    {
        if (_isSpeedUped) return;
        _isSpeedUped = true;
        foreach(var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.UpgradeCoolingDown(_asUpgradeValue);
        }
    }

    private void SetDefaultSpeed()
    {
        if (!_isSpeedUped) return;
        _isSpeedUped = false;
        foreach (var weapon in Movement.singleton.GetComponentsInChildren<Weapon>())
        {
            weapon.DegradeCoolingDown(_asUpgradeValue);
        }
    }
}
