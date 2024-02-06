using CodeHelper.Unity;
using UnityEngine;

public class AbilityShop : MonoBehaviour
{
    [SerializeField] private InGameWallet _wallet;
    [SerializeField] private Canvas _abilityCanvas;
    [SerializeField] private Transform _container;
    [SerializeField] private SpellCard _card;

    private void Start() => _wallet.OnLevelUP += OpenShop;
    
    public void OpenShop()
    {
        Game.Pause();
        _abilityCanvas.enabled = true;
        _container.Clear();
        for(int i = 0; i <3; i++)
        {
            if(i == 0)
            {
                var c = _container.Add(_card);
                c.OnSpellChoised += (_) =>
                {
                    Game.Unpause();
                    _abilityCanvas.enabled = false;
                };
                c.Render((int)SpellStruct.CurrentType, Random.Range(1, SpellStruct.Spells.Count -1));
                continue;
            }
            var card = _container.Add(_card);
            card.OnSpellChoised += (_) =>
            {
                Game.Unpause();
                _abilityCanvas.enabled = false;
            };
            card.Render(Random.Range(1, SpellStruct.Spells.Count - 1));
        }
    }
}
