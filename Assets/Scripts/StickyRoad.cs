using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyRoad : MonoBehaviour
{


    public float TargetDistance = 0;
    public float Strength = 1000;
    public float RotationSpeed = 1;

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
            body.AddForce(-transform.up * Strength * (hit.distance - TargetDistance), ForceMode.Acceleration);

            body.useGravity = false;

            var targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            Vector3 difference = transform.eulerAngles - targetRotation.eulerAngles;

            for (int i = 0; i < 3; i++)
            {
                if ( difference[i] > 180)
                {
                    difference[i] = -360 + difference[i];
                }
                else if (difference[i] < -180)
                {
                    difference[i] = 360 + difference[i];
                }
            }
            body.AddRelativeTorque(RotationSpeed * difference);
        }
        else
        {
            body.useGravity = true;
        }

    }
}
