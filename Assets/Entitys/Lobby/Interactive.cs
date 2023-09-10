using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private Text _nameField;
    [SerializeField] private string _name;

    private void OnCollisionExit2D(Collision2D collision) => Disable();

    private void OnTriggerEnter2D(Collider2D collision) => Enable();

    private void Disable()
    {
        _nameField.enabled = false;
        _bg.enabled = false;
        _nameField.text = string.Empty;
    }

    private void Enable()
    {
        _nameField.enabled = true;
        _bg.enabled = true;
        _nameField.text = _name;
    }
}
