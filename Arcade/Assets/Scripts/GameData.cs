using UnityEngine;

[CreateAssetMenu(menuName = "Game/Settings", fileName = "GameData")]
public class GameData : ScriptableObject
{
    [Tooltip("Префаб игрока.)")]
    [SerializeField] private GameObject _playerPrefab;
    [Tooltip("Кол-во жизней у игрока.")]
    [SerializeField] private int _lives = 0;
    [Tooltip("Раз в сколько секунд спавнятся астероиды.")]
    [SerializeField] private float _timing = 0;
    [Tooltip("В каком кол-ве спавнятся астероиды.")]
    [SerializeField] private int _count = 0;

    public GameObject PlayerPrefab { get => _playerPrefab; }
    public int Lives { get => _lives; }
    public float Timing { get => _timing; }
    public int Count { get => _count; }
}
