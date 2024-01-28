using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DescriptionOnPoiner : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private TextMeshProUGUI _descriptionField;
    [SerializeField] private string _text;
    public void OnPointerEnter(PointerEventData eventData) =>
        _descriptionField.text = _text;
    public void SetText(string text) => 
        _text = text;

}
