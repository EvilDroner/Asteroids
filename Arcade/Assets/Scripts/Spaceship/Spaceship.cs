﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour, IDestructable
{
    [SerializeField] private SpaceshipData _shipData;

    private SpaceshipMotor _motor;
    private IShipInput _input;
    private Rigidbody2D rg;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    public void Destruct() // Уничтожение корабля
    {
        AsteroidSounds.Instance.PlaySound("Boom");
        ExplosionController.MakeExplosion(transform.position);
        GameController.Instance.HandleDeath();
    }

    private void OnEnable() // Инициализация компонентов
    {
        _input = new ShipInput();
        _motor = new SpaceshipMotor(_input, _shipData, rg);
    }

    void Update()
    {
        _input.ReadInput();
        _motor.Tick();
    }
}
