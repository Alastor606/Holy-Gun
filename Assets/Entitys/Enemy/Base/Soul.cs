using System;
using UnityEngine;

public class Soul : MonoBehaviour
{
    public Action<Soul> OnTake;
    [SerializeField] private int _value;

    public void Take(InGameWallet wallet)
    {
        wallet.Add(_value);
        OnTake?.Invoke(this);
        Destroy(this.gameObject);
    }
}
