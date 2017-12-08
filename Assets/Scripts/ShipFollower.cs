using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollower : MonoBehaviour {

    public ShipPreparer ShipPreparer;

    private Transform ship;

    public Vector3 MinPos = new Vector3(0,3,-5);
    public Vector3 MaxPos = new Vector3(0,6,-10);
    public float MinAngle = 0.15f;
    public float MaxAngle = 0.335f;

    public float SpeedMultiplier = 0.02f;

    public Vector3 MovementSpeed = new Vector3(10, 0.5f, 10);
    public float RotationSpeed = 5f;

    private Rigidbody shipBody;

    // Use this for initialization
	void Start () {
        ship = ShipPreparer.ship;

        transform.SetParent(ship);

        shipBody = ship.GetComponentInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(ship);

        Vector3 targetPosition = ship.TransformPoint(Vector3.Lerp(MinPos, MaxPos, SpeedMultiplier * Vector3.Magnitude(shipBody.velocity)));
        
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, targetPosition.x, MovementSpeed.x),
            Mathf.Lerp(transform.position.y, targetPosition.y, MovementSpeed.y),
            Mathf.Lerp(transform.position.z, targetPosition.z, MovementSpeed.z));

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x + Mathf.Lerp(MinAngle, MaxAngle, SpeedMultiplier), transform.eulerAngles.y, ship.eulerAngles.z);
    }
}
