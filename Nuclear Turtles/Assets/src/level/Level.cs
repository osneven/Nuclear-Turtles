using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

	private Vector2[] waypoints;

	// Use this for initialization
	void Start () {

		// Get the waypoints
		waypoints = FindWaypoins();
	}
	
	// Update is called once per frame
	void Update () {}

	private Vector2[] FindWaypoins() {

		// Get all waypoints
		GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");

		// Get all the positions
		Vector2[] waypoints = new Vector2[waypointObjects.Length];
		for (int i = 0; i < waypointObjects.Length; i ++) {
			Vector3 pos = waypointObjects[i].transform.position;
			waypoints[i] = new Vector2(pos.x, pos.y);
		}

		return waypoints;
	}

	public Vector2 NextWaypoint(int index) {
		return waypoints[index + 1];
	}
	public Vector2 FirstWaypoint() {
		return waypoints[0];
	}
	public bool IsFinalWaypoint(Vector2 waypoint) {
		return false;//waypoint == waypoints[waypoints.Length - 1];
	}
	public bool IsOnWaypoint(Vector2 point, Vector2 waypoint, float error) {
		float r = Mathf.Sqrt(Mathf.Pow(waypoint.x-point.x, 2) + Mathf.Pow(waypoint.y-point.y, 2));
		return r <= error;
	}
}
