using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Collections;
using CodeHelper;

[RequireComponent(typeof(FabrickController))]
public class EnemyFabrick : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private FabrickController _controller;
    [Header("Enemy")]
    [SerializeField] private BossMark _boss;
    [SerializeField] private List<EnemyStats> _easyEnemy, _mediumEnemy, _hardEnemy;
    [Header("Stats")]
    [SerializeField] private Vector2 _spawnArea;
    [SerializeField, Range(0.5f,3)] private float _interval;
    [SerializeField, Range(1,20)] private int _enemyPerSpawn;
    private bool _isSpawning = false;
    private int _currentLevel = 0;

    private EnemyStats RandomEasyEnemy() =>
        _easyEnemy.GetRandom(); 

    private EnemyStats RandomHardEnemy() =>
        _hardEnemy.GetRandom(); 

    private EnemyStats RandomMediumEnemy()=> 
        _mediumEnemy.GetRandom();

    private void Awake()
    {
        _controller.OnLevelStarted += () => StartCoroutine(nameof(SpawnEnemy));
        _controller.OnWaveFinished += () => _isSpawning = false;
    }

    private EnemyStats ChooseEnemy()
    {
        if (_currentLevel <= 4) return RandomEasyEnemy();
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

    private IEnumerator SpawnEnemy()
    {
        _isSpawning = true;
        while(_isSpawning)
        {
            for (int i = 0; i < _enemyPerSpawn; i++)
            {
                Vector2 spawnPoint = new(UnityEngine.Random.Range(-_spawnArea.x / 2f, _spawnArea.x / 2f),
                UnityEngine.Random.Range(-_spawnArea.y / 2f, _spawnArea.y / 2f));    
                Game.Instance(ChooseEnemy().GetComponent<EnemyHealth>(), spawnPoint);
            }
            yield return new WaitForSeconds(_interval);
        }
        Game.ClearAll();
    }

    private async void SpawnBoss()
    {
        await Task.Delay(5000);
        var boss = Game.Instance(_boss, Vector3.zero); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(_spawnArea.x, _spawnArea.y, 0f));
    }

}
