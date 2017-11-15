using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyRoad : MonoBehaviour
{


    public float TargetDistance = 0;
    public float Strength = 1000;
    public float RotationSpeed = 10;

    Rigidbody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1000f))
        {
            if (hit.distance > TargetDistance)
            {
                body.AddForce(-transform.up * Strength * (hit.distance - TargetDistance), ForceMode.Acceleration);
            }
            else
            {
                body.AddForce(-transform.up * Strength * (hit.distance - TargetDistance), ForceMode.Acceleration);
            }
            body.useGravity = false;
            var targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        }
        else
        {
            body.useGravity = true;
        }

    }
}
