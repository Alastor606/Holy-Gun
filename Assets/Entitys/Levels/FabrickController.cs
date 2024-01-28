using System;
using System.Threading.Tasks;
using UnityEngine;

public class FabrickController : MonoBehaviour
{
    public Action OnLevelStarted;
    public Action OnWaveFinished;
    public Action<int> OnTimerValueChanged;
    [SerializeField] private int _levelTime;

    private void Start() => 
        Movement.singleton.GetComponent<AbilityChoise>().OnAbilityChoised += Timer;
    private void OnDestroy() =>
        OnWaveFinished?.Invoke();

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
        OnWaveFinished?.Invoke();
        Game.HealUpPlayer();
    }

    public void StartTimer() => Timer();
}
