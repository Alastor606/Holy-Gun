using UnityEngine;
using UnityEngine.UI;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Text _nameField;
    [SerializeField] private Button _acceptButton;

    private void OnTriggerExit2D(Collider2D collision)
    {
        _acceptButton.gameObject.SetActive(false);
        _nameField.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _acceptButton.gameObject.SetActive(true);
        _nameField.enabled = true;
    }


}
