using CodeHelper.Unity;
using UnityEngine;

public class AbilityShop : MonoBehaviour
{
    [SerializeField] private Canvas _abilityCanvas;
    [SerializeField] private Transform _container;
    [SerializeField] private SpellCard _card;

    public void OpenShop()
    {
        _abilityCanvas.enabled = true;
        _container.Clear();
        for(int i = 0; i <3; i++)
        {
            var card = _container.Add(_card);
            card.Render(Random.Range(0, SpellStruct.Spells.Count));
        }
    }
}
