using System;
using UnityEngine;
using System.Threading.Tasks;

public class AbilityChoise : MonoBehaviour
{
    [SerializeField] private SpellCard _card;
    [SerializeField] private Canvas _canvas;
    public Action OnAbilityChoised;
    private bool _isAbilityChoising = true;
    private int index = 0;

    public void RenderCard() =>
        _card.Render(index);
    public void Next()
    {
        if (SpellStruct.Spells.Count - 1> index) index++;
        else index = 0;
        RenderCard();
    }
        
    public void Previous()
    {
        if (index - 1 >= 0) index--;
        else index = SpellStruct.Spells.Count - 1;
        RenderCard();
    }
        
    public async void RenderAbilityChoise()
    {
        _card.Render(index);
        _card.OnSpellChoised += ChoiseAbility;
            
        _canvas.enabled = true;
        while (_isAbilityChoising)
        {
            await Task.Yield();
        }
        OnAbilityChoised?.Invoke();
    }

    public void ChoiseAbility(SpellTypes type)
    {
        _isAbilityChoising = false;
        _canvas.enabled = false;
    }
}
