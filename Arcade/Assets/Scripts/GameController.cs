using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameData _data;

    private GameObject _player;
    private int _score = 0;
    private int _livesLeft = 3;

    private TimingAsteroidGenerator _timingGenerator;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLivesLeftChanged;

    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Trying to use uninitialized GameController!");
            }
            return _instance;
        }
        private set
        {
            if (_instance == null)
            {
                _instance = value;
            }
            else
            {
                Debug.LogError($"Trying to initialize GameController  multiple time.");
            }
        }
    }

    private void Awake()
    {
        Instance = this;
        if(_data == null)
        {
            Debug.LogError("No GameData provided!");
        }
    }
    private void Start()
    {
        _timingGenerator = new TimingAsteroidGenerator(RandomPlacedAsteroidGenerator.Instance, _data.Timing, _data.Count);
        _player = Instantiate(_data.PlayerPrefab);
        _timingGenerator.Enable();
        InitNewGame();
    }
    private void Update()
    {
        _timingGenerator.Tick();
    }
    public void AddScore(int count) // Изменение кол-ва очков
    {
        _score += count;
        OnScoreChanged?.Invoke(_score);
    }

    public void HandleDeath() // Изменение кол-ва хп
    {
        _livesLeft--;
        _livesLeft = (_livesLeft >= 0 ? _livesLeft : 0);
        OnLivesLeftChanged?.Invoke(_livesLeft);
        _player.transform.position = Vector3.zero;
        if (_livesLeft == 0)
        {
            GameOver();
        }
    }
    private void InitNewGame() // Инициализация новой игры
    {
        _score = 0;
        _livesLeft = _data.Lives;
        OnScoreChanged?.Invoke(_score);
        OnLivesLeftChanged?.Invoke(_livesLeft);
  
    }
    private void GameOver() // Обработка конца игры
    {
        InitNewGame();
    }
}
