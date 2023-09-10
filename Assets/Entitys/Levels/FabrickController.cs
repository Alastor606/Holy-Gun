using System;
using System.Threading.Tasks;
using UnityEngine;

public class FabrickController : MonoBehaviour
{
    public Action OnLevelStarted;
    public Action OnLevelFinished;
    public Action<int> OnTimerValueChanged;
    [SerializeField] private int _levelTime;

    private void Start() => Timer();
    private void OnDestroy() =>
        OnLevelFinished?.Invoke();

    private async void Timer()
    {
        OnLevelStarted?.Invoke();
        var time = _levelTime;
        while (time != 0)
        {
            await Task.Delay(1000);
            time--;
            OnTimerValueChanged?.Invoke(time);
        }
        OnLevelFinished?.Invoke();
    }

    

}
