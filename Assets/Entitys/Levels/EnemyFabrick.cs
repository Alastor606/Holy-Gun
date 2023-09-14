using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using static UnityEngine.EventSystems.EventTrigger;
using System.Runtime.InteropServices.WindowsRuntime;

public class EnemyFabrick : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private FabrickController _controller;
    [Header("Enemy")]
    [SerializeField] private BossMark _boss;
    [SerializeField] private List<EnemyStats> _easyEnemy;
    [SerializeField] private List<EnemyStats> _mediumEnemy;
    [SerializeField] private List<EnemyStats> _hardEnemy;
    [Header("Stats")]
    [SerializeField] private Vector2 _spawnArea;
    [SerializeField, Range(0.5f,3)] private float _interval;
    [SerializeField, Range(1,20)] private int _enemyPerSpawn;
    private bool _isSpawning = false;
    private int _currentLevel = 0;

    private EnemyStats RandomEasyEnemy()
    { return _easyEnemy[UnityEngine.Random.Range(0, _easyEnemy.Count - 1)]; }

    private EnemyStats RandomHardEnemy()
    { return _hardEnemy[UnityEngine.Random.Range(0, _hardEnemy.Count - 1)]; }

    private EnemyStats RandomMediumEnemy()
    { return _mediumEnemy[UnityEngine.Random.Range(0, _mediumEnemy.Count - 1)]; }

    private void Awake()
    {
        _controller.OnLevelStarted += SpawnEnemy;
        _controller.OnLevelFinished += () => _isSpawning = false;
    }

    private EnemyStats ChooseEnemy()
    {
        if (_currentLevel <= 4)
            return RandomEasyEnemy();
        else if (_currentLevel > 4 && _currentLevel <= 7)
        {
            var random = UnityEngine.Random.Range(0,1);
            if (random == 0) return RandomEasyEnemy();
            else return RandomMediumEnemy();
        }
        else
        {
            var random = UnityEngine.Random.Range(0, 2);
            if (random == 0) return RandomEasyEnemy();
            else if (random == 1) return RandomMediumEnemy();
            else return RandomHardEnemy();
        }
    }

    private async void SpawnEnemy()
    {
        _isSpawning = true;
        while(_isSpawning)
        {
            for (int i = 0; i < _enemyPerSpawn; i++)
            {
                Vector2 spawnPoint = new Vector2(UnityEngine.Random.Range(-_spawnArea.x / 2f, _spawnArea.x / 2f),
                UnityEngine.Random.Range(-_spawnArea.y / 2f, _spawnArea.y / 2f));    
                Instantiate(ChooseEnemy(), spawnPoint, Quaternion.identity);
            }
            await Task.Delay(TimeSpan.FromSeconds(_interval));
        }
        ClearZone();
    }

    private void ClearZone()
    {
        var enemys = GameObject.FindObjectsOfType<EnemyStats>();
        foreach (var enemy in enemys) Destroy(enemy?.gameObject);
    }

    private async void SpawnBoss()
    {
        await Task.Delay(5000);
        var boss = Instantiate(_boss, Vector3.zero, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnArea.x, _spawnArea.y, 0f));
    }

}
