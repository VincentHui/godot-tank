using Godot;
using System;

public partial class AiSimplePatrol : Sprite2D
{
  private float speed = 10f;

  public override void _Ready()
  {
    GD.Print("START AI");
  }
  public override void _Process(double delta)
  {
    // Vector2 velocity = Vector2.Zero;
    Position += new Vector2(1, 0) * speed * (float)delta;
  }
}
