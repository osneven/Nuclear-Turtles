using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private int health;

	// Use this for initialization
	void Start () {
		health = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Debug.Log("PLAYER IS DEAD");
		}
	}

	public void DecreaseHealth(int amount) {
		health -= amount;
	}
	/// <summary>
	/// Decreases the health with 1.
	/// </summary>
	public void DecreaseHealth() {
		DecreaseHealth(1);
	}
}
