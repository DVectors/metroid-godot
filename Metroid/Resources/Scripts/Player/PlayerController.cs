using Godot;
using System;

public partial class PlayerController : CharacterBody2D
{
	private AnimatedSprite2D _animatedSprite; // Get sprite animator
	private Vector2 _velocity;
	
	public const float Speed = 125.0f;
	public const float JumpVelocity = -400.0f;
	
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("walk_left") && IsOnFloor() || Input.IsActionPressed("walk_right") && IsOnFloor())
		{
			_animatedSprite.Play("walk");
		}
		else if (!IsOnFloor()) // Play jump animation
		{
			_animatedSprite.Play("jump");
		}
		else
		{
			_animatedSprite.Play("idle");
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		// Add the gravity.
		if (!IsOnFloor())
		{
			_velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			_velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		float direction = Input.GetAxis("walk_left", "walk_right");
		if (direction != 0f) // 0f = standing still
		{
			_velocity.X = direction * Speed;
		}
		else
		{
			_velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}
		
		// Flip depending on velocity
		if (_velocity.X > 0f)
		{
			_animatedSprite.FlipH = false;
		}
		else if (_velocity.X < 0f)
		{
			_animatedSprite.FlipH = true;
		}

		Velocity = _velocity;
		MoveAndSlide();
	}
}
