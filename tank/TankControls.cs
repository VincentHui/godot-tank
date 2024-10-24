using Godot;
using System;

public partial class TankControls : Sprite2D
{
  private int _speed = 400;
  private float _angularSpeed = Mathf.Pi;
  private float _boostMultiplier = 2.5f;
  private bool _boosting = false;

  private Node2D _child = null;

  public override void _Ready()
  {
    _child = GetNode<Node2D>("cannon");
  }

  public override void _Process(double delta)
  {
    //Rotation -=  _angularSpeed * (float)delta;
    int currentSpeed = _speed;
    if (_boosting)
    {
      currentSpeed = (int)_boostMultiplier;
    }

    var velocity = Vector2.Up.Rotated(Rotation) * _speed;
    //
    //Position += velocity * (float)delta;
    var direction = 0;
    var cannonDirection = 0;
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
      direction = -1;
    }
    if (Input.IsActionPressed("ui_right"))
    {
      direction = 1;
    }
    if (Input.IsActionPressed("ui_up"))
    {
      Position += velocity * (float)delta;
    }
    if (Input.IsActionPressed("ui_down"))
    {
      Position -= velocity * (float)delta;
    }
    if (Input.IsActionPressed("ui_select") && !_boosting)
    {
      Position += velocity * (float)delta * _boostMultiplier;
    }

    Rotation += _angularSpeed * direction * (float)delta;
    _child.Rotation += _angularSpeed * cannonDirection * (float)delta;
  }
}
