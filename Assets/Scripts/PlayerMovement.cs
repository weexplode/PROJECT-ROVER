﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float turnspeed;
	
	void Update () {
        float forward = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        float delta = Time.deltaTime;
        transform.Translate(Vector3.forward * forward * speed * delta);
        transform.Rotate(0, turn * turnspeed * delta, 0);
	}
}