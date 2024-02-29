using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SpellCard : MonoBehaviour
{
    public Action<SpellTypes> OnSpellChoised;
    [SerializeField] private TextMeshProUGUI _descriptionField, _nameField;
    [SerializeField] private Image _imageField, _typeField;
    private Dictionary<int, int> _givenValues = new();
    public Spell CurrentSpell { get; private set; }

    public bool Render(int index, int spellIndex = 0)
    {
        if (_givenValues.TryGetValue(index, out var value)) return false;
        
        _descriptionField.text = SpellStruct.Spells[index][spellIndex].Description;
        CurrentSpell = SpellStruct.Spells[index][spellIndex];
        _nameField.text = SpellStruct.Spells[index][spellIndex].Name;
        _givenValues.Add(index, spellIndex);
        if (spellIndex == 0) SpellStruct.SetCurrentType(SpellStruct.Spells[index][spellIndex].Type);
        
        return true;
    }

    public void Choise()
    {
        OnSpellChoised?.Invoke(CurrentSpell.Type);
    }   
    
}