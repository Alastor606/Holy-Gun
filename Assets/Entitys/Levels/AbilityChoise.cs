using System;
using UnityEngine;
using System.Threading.Tasks;

public class AbilityChoise : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    public Action OnAbilityChoised;
    private bool _isAbilityChoising = true;

    private async void Start()
    {
        await Task.Delay(1000);
        _canvas.enabled = true;
        while (_isAbilityChoising)
        {
            await Task.Yield();
        }
        _canvas.enabled = false;
        OnAbilityChoised?.Invoke();
    }

    public void ChoiseAbility()=>
        _isAbilityChoising = false;
    
}
