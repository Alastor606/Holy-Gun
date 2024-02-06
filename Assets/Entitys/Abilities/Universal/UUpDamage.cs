using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Universal/Up damage")]
public class UUpDamage : AssetSpell
{
    [SerializeField] private float _upDamage;
    private List<float> _mainDamages;
    public override void OnTake()
    {
        Game.Health.OnValueChanged += Check;
    }

    private void Check(float max, float current)
    {
        if(max == current)
        {
            _mainDamages.Clear();
            foreach(var item in Movement.singleton.GetComponentsInChildren<Weapon>())item.UpgradeDamage(_upDamage);
        }
        else
        {
            int index = 0;
            foreach (var item in Movement.singleton.GetComponentsInChildren<Weapon>())
            {
                item.DegradeDamage(item.Damage - _mainDamages[index]);
                index++;
            }
        }
    }
}
