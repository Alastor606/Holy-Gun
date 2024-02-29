using CodeHelper.Unity;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private FabrickController _controller;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Shopcell _cell;
    [SerializeField] private Transform _container;

    private void Start()
    {
        _controller.OnWaveFinished += Show;
    }

    public void Show()
    {
        _container?.Clear();
        _canvas.enabled = true;
        for(int i = 0; i< 3; i++)
        {
            var cell = Instantiate(_cell,_container);
            cell.Render(ShopResourses.GetRandomItem());
        }
    }

    public void Continue()
    {
        _canvas.enabled = false;
        _controller.StartTimer();
    }
}
