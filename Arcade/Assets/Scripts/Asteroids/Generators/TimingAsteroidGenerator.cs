using UnityEngine;

public class TimingAsteroidGenerator
{
    [SerializeField] private IAsteroidGenerator _generator;
    private bool _isActive = false;
    private float _timing = 0f;
    private float _time = 0f;
    private int _countPerTime = 0;

    public TimingAsteroidGenerator(IAsteroidGenerator generator, float timing, int countPerTime) // Инициализация
    {
        _generator = generator;
        _timing = timing;
        _countPerTime = countPerTime;
    }

    public void Enable()
    {
        _isActive = true;
    }
    public void Disable()
    {
        _isActive = false;
    }
    public void Tick() // 
    {
        _time -= Time.deltaTime;
        if (_isActive && _time <= 0)
        {
            _generator.GenAsteroids(_countPerTime);
            _time = _timing;
        }
    }
}
