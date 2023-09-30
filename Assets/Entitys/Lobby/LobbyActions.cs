using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LobbyActions : MonoBehaviour
{
    [SerializeField] private List<Level> _levels;
    [SerializeField] private GameObject _lobby;
    private GameObject _currentLevel;

    private void Start()
    {
        Movement.singleton.GetComponent<PlayerHealth>().OnDie += OnPlayerDie;
    }

    public async void StartLevel()
    {
        _currentLevel = Instantiate(_levels[0].LevelArea, Vector3.zero, Quaternion.identity);
        await Task.Delay(500);
        Destroy(_lobby);
        await Task.Delay(500);
        Movement.singleton.transform.position = Vector3.zero;
    }

    private async void OnPlayerDie()
    {
        Destroy(_currentLevel);
        Instantiate(_lobby, Vector3.zero, Quaternion.identity);
        await Task.Delay(500);
        Movement.singleton.gameObject.SetActive(true);
    }
}
