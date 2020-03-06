using System.Collections.Generic;
using UnityEngine;

public abstract class SoundsList<T> : MonoBehaviour where T : class
{
    [SerializeField] private SerializableStringAduiClipDictionary _sounds;
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError($"Trying to use uninitialized sounds manager!");
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
                Debug.LogError($"Trying to initialize {typeof(T).Name} sound manager multiple time.");
            }
        }
    }
    private void Awake()
    {
        Instance = this as T;
    }
    public void PlaySound(string name) // Воспроизводим аудио
    {
        if (_sounds.ContainsKey(name))
        {
            SoundManager.Instance.PlaySound(name);
        }
        else
        {
            Debug.LogError($"Sounds list of {typeof(T).Name} doesnt have {name} sound in list");
        }
    }
    private void Start() // Добавляем дорожки в основной список
    {
        foreach (var sound in _sounds)
        {
            SoundManager.Instance.AddSound(sound.Key, sound.Value);
        }
    }
}
