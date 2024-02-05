using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCard : MonoBehaviour
{
    public Action<SpellTypes> OnSpellChoised;
    [SerializeField] private TextMeshProUGUI _descriptionField, _nameField;
    [SerializeField] private Image _imageField, _typeField;
    public Spell CurrentSpell { get; private set; }

    private void ButtonListnerAdd(Spell spell)
    {
        var button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(delegate { spell.OnTake(); OnSpellChoised?.Invoke(spell.Type); });
    }

    public void Render(int index, int spellIndex = 0)
    {
        _descriptionField.text = SpellStruct.Spells[index][spellIndex].Description;
        CurrentSpell = SpellStruct.Spells[index][spellIndex];
        _nameField.text = SpellStruct.Spells[index][spellIndex].Name;
        if(spellIndex == 0)ButtonListnerAdd(SpellStruct.Spells[index][spellIndex]); 
    }

    public void Choise() =>
        OnSpellChoised?.Invoke(CurrentSpell.Type);
    
}