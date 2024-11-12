using Godot;
using System;

public partial class character : CharacterBody2D
{
  [Export] private PackedScene bulletPath;
  public const float Speed = 250.0f;
  public const float Acceleration = 1.0f;
  public const float RotationSpeed = 2.0f;
  public const float Deceleration = 0.5f;
  public const float _angularSpeed = Mathf.Pi;
  public const float _boostMultiplier = 1.5f;
  private bool _boosting = false;
  public float MaxFuel = 100.0f;
  public float CurrentFuel {get; set;}
  public float FuelConsumptionRate = 10f;

  private Node2D _child = null;

  public override void _Ready()
  {
    _child = GetNode<Node2D>("cannon");
    CurrentFuel = MaxFuel;
  }

  private void _shoot()
  {
    GD.Print("fire");
    var bullet = bulletPath.Instantiate();
    // var bullet = new Bullet();
    // bullet.Position = GetNode<Marker2D>("Marker2D").Position;

    GetParent().AddChild(bullet);
  }


  public override void _PhysicsProcess(double delta)
  {
    Vector2 velocity = Vector2.Zero;
    

    var currentSpeed = Speed;
    var cannonDirection = 0;

    if (_boosting)
    {
      currentSpeed = (int)_boostMultiplier;
    }
    if (Input.IsActionPressed("cannonLeft"))
    {
      cannonDirection = -1;
    }
    if (Input.IsActionPressed("cannonRight"))
    {
      cannonDirection = 1;
    }
    if (Input.IsActionPressed("ui_left"))
    {
      Rotation -= RotationSpeed * (float)delta;
    }
    if (Input.IsActionPressed("ui_right"))
    {
      Rotation += RotationSpeed * (float)delta;
    }

    if (Input.IsActionPressed("ui_up"))
    {
      velocity += Vector2.Up.Rotated(Rotation) * Speed;
      // if (velocity = Vector2.(Speed)){velocity += Vector2.Up.Rotated(Rotation) * Speed;};
    }
    if (Input.IsActionPressed("ui_down"))
    {

      velocity += Vector2.Up.Rotated(Rotation) * Speed * -Deceleration;
    }
    if (Input.IsActionPressed("ui_select") && !_boosting)
    {
      velocity += Vector2.Up.Rotated(Rotation) * Speed * _boostMultiplier;
    }

    if (Input.IsActionJustPressed("ui_accept"))
    {
      _shoot();
    }

    if (velocity.Length() > 0 || _boosting)
    {
      CurrentFuel -= FuelConsumptionRate * (float)delta;
    }

    if (CurrentFuel <= 0)
    {
      CurrentFuel = 0;
      velocity = Vector2.Zero;
      GD.Print("Fresh Out of Fuel!!");
    }



    _child.Rotation += _angularSpeed * cannonDirection * (float)delta; Velocity = velocity;
    MoveAndSlide();
  }
}



