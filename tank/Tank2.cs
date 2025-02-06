using Godot;
using System;

public partial class Tank2 : Sprite2D
{
	[Export]
	private int _speed = 200;
	
	// This array holds the points the tank will move to
	private Vector2[] _patrolPoints;
	private int _currentPointIndex = 0;
	
	// This runs once when you press play
	public override void _Ready()
	{
		// Set up the patrol points
		_patrolPoints = new Vector2[]
		{
			new Vector2(300, 0),    // First point - right
			new Vector2(300, 300),  // Second point - down
			new Vector2(290, 285),
			new Vector2(300, 300),
			new Vector2(0, 300),    // Third point - left
			new Vector2(150, 150),
			new Vector2(0, 0)       // Fourth point - back to start
		};
		
		GD.Print("AI Tank started!"); // This will print when the tank starts moving
	}

	// This runs every frame automatically
	public override void _Process(double delta)
	{
		// Get the point we're moving towards
		Vector2 targetPoint = _patrolPoints[_currentPointIndex];
		
		// Move towards the target point
		Vector2 direction = (targetPoint - Position).Normalized();
		Position += direction * _speed * (float)delta;
		
		// Check if we've reached the point (within 10 pixels)
		if (Position.DistanceTo(targetPoint) < 10)
		{
			// Move to next point in the array
			_currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Length;
			GD.Print($"Moving to point {_currentPointIndex}"); // This will print when reaching each point
		}
	}
}
