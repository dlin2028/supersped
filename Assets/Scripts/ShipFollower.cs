using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollower : MonoBehaviour {

    public Transform Ship;
    private Rigidbody shipBody;

    public float MinDistance;
    public float MaxDistance;

    public float MinCameraAngle;
    public float MaxCameraAngle;

    public float SpeedMultiplier;
    public float CameraAngle = -0.335f;

    private Vector3 minPos;
    private Vector3 maxPos;

    // Use this for initialization
    
    
	void Start () {
        transform.position = transform.position;
        transform.LookAt(Ship);

        transform.position = Ship.position;
        transform.position -= transform.forward * MinDistance;
        minPos = transform.position;

        transform.position = Ship.position;
        transform.position -= transform.forward * MaxDistance;
        maxPos = transform.position;

        shipBody = Ship.GetComponentInChildren<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Ship.TransformPoint(Vector3.Lerp(minPos, maxPos, SpeedMultiplier * transform.InverseTransformDirection(shipBody.velocity).z));
        transform.LookAt(Ship);

        transform.rotation = Quaternion.Euler(
            Mathf.Lerp(MinCameraAngle, MaxCameraAngle, SpeedMultiplier * transform.InverseTransformDirection(shipBody.velocity).z)
            , transform.eulerAngles.y
            , transform.eulerAngles.z);
    }
}
