using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StartForce : MonoBehaviour {

    public Vector3 Torque;
    public Vector3 Force;

    private Rigidbody body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        body.AddForce(Force);
        body.AddTorque(Torque);
	}
}
