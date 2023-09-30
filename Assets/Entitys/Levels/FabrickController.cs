using System;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(AbilityChoise))]
public class FabrickController : MonoBehaviour
{
    public Action OnLevelStarted;
    public Action OnLevelFinished;
    public Action<int> OnTimerValueChanged;
    [SerializeField] private int _levelTime;
    [SerializeField] private AbilityChoise _controller;

    private void Start() => _controller.OnAbilityChoised += Timer;
    private void OnDestroy() =>
        OnLevelFinished?.Invoke();

    private async void Timer()
    {
        OnLevelStarted?.Invoke();   
        int time = _levelTime;
        while (time != 0)
        {
            await Task.Delay(1000);
            time--;
            OnTimerValueChanged?.Invoke(time);
        }
        OnLevelFinished?.Invoke();
    }

    

}
