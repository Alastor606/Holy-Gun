using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] private int _value;

    public void Take(InGameWallet wallet)
    {
        wallet.Add(_value);
        Destroy(this.gameObject);
    }
}
