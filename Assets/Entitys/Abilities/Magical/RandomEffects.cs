using UnityEngine;
using Effects;
using CodeHelper;

[CreateAssetMenu(menuName = "Spells/Magic/Rand Effects")]
public class RandomEffects : AssetSpell
{
    public override void OnTake()
    {
        Movement.singleton.GetComponentsInChildren<Weapon>().AllDo((item) =>
        {
            item.Additional += (value) =>
            {
                var rand = Random.Range(0, 2);
                switch (rand)
                {
                    case 0:
                        new Froze(1).Freeze(value.GetComponent<EnemyMovement>());
                        break;
                    case 1:
                        Movement.singleton.StartCoroutine(new Bleeding(10).Bleed(value));
                        break;
                    case 2:
                        Movement.singleton.StartCoroutine(new Fire(5, 6).DealDamage(value));
                        break;
                }
            };
        });
    }  
}
