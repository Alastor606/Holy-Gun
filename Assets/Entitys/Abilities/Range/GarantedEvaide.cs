using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Range/GarantedEvasion")]
public class GarantedEvaide : AssetSpell
{
    [SerializeField] private float _time;
    private float _baseEvasion;
    private bool _isAlive = true;
    public override async void OnTake() 
    {
        Game.Health.OnDie += () => _isAlive = false;
        _baseEvasion = Game.Health.Evasion;
        var time = 0;
        while (_isAlive)
        {
            await Task.Delay(1000);
            time ++;
            if(time >= _time)
            {
                CheckEvade();
                time = 0;
            }
        }
    }

    private void CheckEvade()
    {
        var player = Game.Health;
        player.Evasion = 100;
        player.OnEvade += () => player.Evasion = _baseEvasion;
    }
}
