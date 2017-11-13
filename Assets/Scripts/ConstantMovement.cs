using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour {

    public Vector3 Movement;
    public Vector3 Rotation;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(Rotation);
        transform.position += Movement;
	}
}
