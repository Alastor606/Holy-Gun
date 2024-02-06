using System;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName ="Spells/Magic/main")]
public class MagMain : AssetSpell
{
    [SerializeField] private HolyWave _wave;
    [SerializeField] private float _time;
    private bool _enabled = false;
    public override async void OnTake()
    {
        HolyWave wave = Instantiate(_wave, Movement.singleton.transform);
        _enabled = true;
        Game.Health.OnDie += () =>
        {
            Destroy(wave.gameObject);
            _enabled = false;
        };

        while (_enabled)
        {
            await Task.Delay(TimeSpan.FromSeconds(_time));
            wave.Attack();
        }
    }
}

