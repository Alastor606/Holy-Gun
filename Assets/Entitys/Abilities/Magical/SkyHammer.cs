using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Magic/Hammer")] 
public class SkyHammer : AssetSpell
{
    [SerializeField] private MagicHammer _hammer;
    [SerializeField] private float _time, _animatonTime;
    private bool _enabled = false;

    public override async void OnTake()
    {
        _enabled = true;
        while (_enabled)
        {
            await Task.Delay(TimeSpan.FromSeconds(_time));
            var hamer = Instantiate(_hammer, Movement.singleton.transform.position, Quaternion.identity);
            hamer.Attack(_animatonTime);
        }
    }

}
