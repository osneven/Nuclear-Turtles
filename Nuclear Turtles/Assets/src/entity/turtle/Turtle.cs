using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Entity {

	private Level level;
	public float speed;
	private int waypointIndex;
	private Vector2 velocity, waypoint;
	
	public Turtle(Vector2 position) : base(position) {}

	public override void Start() {
		// Get the level script from the level object
		level = GameObject.Find("level").GetComponent<Level>();

		// Get the first waypoint
		waypointIndex = 0;
	}

	public override void Update() {
		// Move the turtle
		Move();
	}

	private void Move() {
		// Move towards the waypoint


		// Check if waypoint has been reached
		if ((Vector2)this.transform.position == waypoint) {
			Vector2 oldWaypoint = waypoint;

			// Check if it's the last waypoint
			if (level.IsFinalWaypoint(waypoint)) {
				// TODO: DECREASE HP OF THE PLAYER
			}

			// Otherwise, get the next waypoint
			else {
				waypoint = level.NextWaypoint(waypointIndex);
				waypointIndex++;
			}

			// Turn the velocity towards the new waypoint
			velocity = Vector2.Angle(oldWaypoint, waypoint);
		}
	}
}
