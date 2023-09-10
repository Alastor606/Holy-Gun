using UnityEngine;

[CreateAssetMenu(menuName ="Level")]
public class Level : ScriptableObject
{
    [SerializeField] private GameObject _levelArea;
    public GameObject LevelArea { get { return _levelArea; } }
    private bool _isCompleted = false;
    public void Win() => _isCompleted = true;
}
