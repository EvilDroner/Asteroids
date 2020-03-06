using UnityEngine;

public class SpaceshipMotor
{
    private IShipInput _input;
    private SpaceshipData _data;
    private Rigidbody2D _ship;

    public SpaceshipMotor(IShipInput input, SpaceshipData data, Rigidbody2D ship) // Инициализируемся
    {
        _input = input;
        _data = data;
        _ship = ship;

        _ship.drag = _data.Drag;
    }
    private void Move()
    {
        _ship.AddForce(_input.Thrust * _ship.transform.up * _data.Acceleration);
        if (_ship.velocity.magnitude > _data.MaxSpeed)
        {
            _ship.velocity = Vector2.ClampMagnitude(_ship.velocity, _data.MaxSpeed);
        }
    }
    private void Rotate()
    {
        _ship.rotation -= (_input.Rotation * _data.TurnSpeed);
    }
    public void Tick()
    {
        Move();
        Rotate();
    }


}
