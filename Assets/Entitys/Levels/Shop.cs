using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private FabrickController _controller;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        _controller.OnWaveFinished += Show;
    }

    public void Show()
    {
        _canvas.enabled = true;
    }

    public void Continue()
    {
        _canvas.enabled = false;
        _controller.StartTimer();
    }
}
