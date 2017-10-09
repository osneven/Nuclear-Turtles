using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour {

	public Entity(Vector2 position) {
		this.transform.position = position;
	}
	
	// Use this for initialization
	public abstract void Start();

	// Update is called once per frame
	public abstract void Update();
}
