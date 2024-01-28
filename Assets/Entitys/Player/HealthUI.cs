using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerHealth))]
public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _bar;
    private PlayerHealth _health;
    private void Start()
    {
        _health = GetComponent<PlayerHealth>();
        _health.OnValueChanged += Render;
    }

    private void Render(float max, float current)
    {
        if (_bar == null) return;
        _bar.fillAmount = current/max;
    }
}
