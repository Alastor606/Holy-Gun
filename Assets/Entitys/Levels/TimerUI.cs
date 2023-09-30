using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FabrickController))]
public class TimerUI : MonoBehaviour
{
    [SerializeField] private FabrickController _controller;
    [SerializeField] private Text _timer;
    private void Awake() =>
        _controller.OnTimerValueChanged += Render;
    
    private void Render(int value) =>
        _timer.text = TimeSpan.FromSeconds(value).ToString(@"mm\:ss");
    
}
