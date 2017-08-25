using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleMovement : MonoBehaviour {
	public float speed = -12f;
	public float points =1;
	public float health = 0;
	public string GemName="";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = new Vector3 (transform.position.x, transform.position.y, transform.position.z -( Time.deltaTime * speed));
		if (pos.z < -20)
			Destroy (gameObject);
		transform.position = pos;
	}

	public float GetPoints(){
		return points;
	}

	public float GetHealth(){
		return health;
	}

	public string GetName(){
		return GemName;
	}
}
