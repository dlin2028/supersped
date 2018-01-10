using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollower : MonoBehaviour {

    public ShipPreparer ShipPreparer;

    private Transform ship;

    public Vector3 PositionOffset = Vector3.zero;
    public Vector3 TargetOffset = Vector3.zero;
    public Vector3 MinPos = new Vector3(0,3,-5);
    public Vector3 MaxPos = new Vector3(0,6,-10);
    public float MinAngle = 0.15f;
    public float MaxAngle = 0.335f;

    public float SpeedMultiplier = 0.02f;
    public float RotationSpeed = 10f;

    private Rigidbody shipBody;

    // Use this for initialization
	void Start () {
        ship = ShipPreparer.ship;

        transform.SetParent(ship);

        shipBody = ship.GetComponentInChildren<Rigidbody>();
    }
	
	void FixedUpdate () {

        Vector3 targetPosition = ship.TransformPoint(Vector3.Lerp(MinPos, MaxPos, SpeedMultiplier * Vector3.Magnitude(shipBody.velocity)));
        transform.position = targetPosition + ship.TransformDirection(PositionOffset);


        transform.up = ship.up;
        transform.LookAt(ship.position + TargetOffset, ship.up);

        transform.Rotate(new Vector3(Mathf.Lerp(MinAngle, MaxAngle, SpeedMultiplier * Vector3.Magnitude(shipBody.velocity)), 0, 0), Space.Self);

        //transform.rotation = Quaternion.Euler(transform.eulerAngles.x + Mathf.Lerp(MinAngle, MaxAngle, SpeedMultiplier * Vector3.Magnitude(shipBody.velocity)), transform.eulerAngles.y, ship.eulerAngles.z);
    }
}
