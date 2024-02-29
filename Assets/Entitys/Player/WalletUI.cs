using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InGameWallet))]
public class WalletUI : MonoBehaviour
{
    [SerializeField] private Image _bar;
    private InGameWallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<InGameWallet>();
        _wallet.OnValueChanged += Render;
    }

    private void Render(int current, int max) =>
        _bar.fillAmount = (float)current / (float)max;
    
}
