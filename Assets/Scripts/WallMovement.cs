﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {
	Renderer rend;
	public float speed = -0.5f;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		float offset = Time.time * speed;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, offset));
	}


}
