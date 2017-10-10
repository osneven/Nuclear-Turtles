using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Entity {

	private Level level;
	private Player player;
	public float speed;
	private int waypointIndex;
	private Vector2 velocity, waypoint;
	
	public Turtle(Vector2 position, float speed) : base(position) {
		this.speed = speed;
	}

	public override void Start() {
		GameObject levelObject = GameObject.Find("level");

		// Get the level script from the level object
		level = levelObject.GetComponent<Level>();
		waypoint = level.FirstWaypoint(); // Get the first waypoint
		waypointIndex = 0; // Set the matching waypoint index

		// Get the player script
		player = levelObject.GetComponent<Player>();

		// Place the the turtle in the start point
		this.transform.position = level.StartPoint();

		//TODO: REMOVE DEBUG TURTLE SPEED
		speed = .1f;
	}

	public override void Update() {
		// Move the turtle
		Move();

		GameObject a = GameObject.Find("Main Camera");
		a.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, a.transform.position.z);
	}

	private void Move() {
		
		// Move towards the waypoint
		this.transform.position += (Vector3) velocity;

		// Check if waypoint has been reached
		if (level.IsOnWaypoint(this.transform.position, waypoint, .1f)) {
			
			// Check if it's the last waypoint, if so, deacrease the player's health by 1, 
			// and destory this turtle
			if (level.IsFinalWaypoint(waypoint)) {
				player.DecreaseHealth();
				Destroy(gameObject);
			}

			// Otherwise, get the next waypoint
			else {
				waypoint = level.NextWaypoint(waypointIndex);
				waypointIndex++;
			}

			// Turn the velocity towards the new waypoint
			velocity = CalculateNewVelocity();
		} else if (velocity == Vector2.zero) {
			velocity = CalculateNewVelocity();
		}
	}

	private Vector2 CalculateNewVelocity() {
		return (waypoint - (Vector2) this.transform.position).normalized * (float) speed;
	}
}
