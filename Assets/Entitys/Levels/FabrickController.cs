using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class FabrickController : MonoBehaviour
{
    public Action OnLevelStarted;
    public Action OnWaveFinished;
    public Action<int> OnTimerValueChanged;
    [SerializeField] private int _levelTime;
    public int _currentLevel { get; private set; } = 0;

    private void Start() => 
        Movement.singleton.GetComponent<AbilityChoise>().OnAbilityChoised += () => StartCoroutine(nameof(Timer));
    private void OnDestroy() =>
        OnWaveFinished?.Invoke();

    private IEnumerator Timer()
    {
        OnLevelStarted?.Invoke();   
        int time = _levelTime;
        while (time != 0)
        {
            yield return new WaitForSeconds(1);
            while (Game.Paused)
            {
                yield return null;
            }
            time--;
            OnTimerValueChanged?.Invoke(time);
        }
        OnWaveFinished?.Invoke();
        _currentLevel++;
        if (_currentLevel == 5) Game.ShowAbilities();
        Game.ClearAll();
        Game.Reset();
    }

    public void StartTimer() => StartCoroutine(nameof(Timer));
}
