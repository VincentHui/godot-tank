// using Godot;
// using System;

// public partial class Bullet : Node2D 
// {
//     [Export] public float Speed = 600f;

//     public override void _Process(double delta)
//     {
        
//         Position += Transform.x * Speed * (float)delta; 
//     }
// }

using Godot;
using System;

public partial class Bullet : Node2D 
{
    [Export] public float Speed = 600f; 

    public override void _Process(double delta)
    {
        
        Vector2 direction = new Vector2(1, 0).Rotated(Rotation); 

        Position += direction * Speed * (float)delta;
    }
}
