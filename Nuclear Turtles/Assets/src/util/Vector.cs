﻿using UnityEngine;

public static class Vector2Extension {

	public static float AngleBetween(Vector2 o, Vector2 p) {
		float a = p.y - o.y, b = p.x - o.x;
	
		return Mathf.Atan(a/b) * Mathf.Deg2Rad;
	}


	public static Vector2 Rotate(Vector2 v, float degrees) {
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (sin * tx) + (cos * ty);
		return v;
	}
}