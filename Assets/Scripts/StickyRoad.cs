using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyRoad : MonoBehaviour
{


    public float TargetDistance;
    public float Strength = 1000;
    public float RotationSpeed;

    RigidBody body;

    // Use this for initialization
    void Start()
    {
        body = GetComponenet<RigidBody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10f))
        {
            if (hit.distance > 5)
            {
                body.AddForce(-transform.up * Strength * (hit.distance - 5) ^ 2, ForceMode.Acceleration);
            }
            else
            {
                body.AddForce(transform.up * Strength * (hit.distance - 5) ^ 2, ForceMode.Acceleration);
            }
            body.useGravity = false;
            var targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);
        }
        else
        {
            body.useGravity = true;
        }

    }
}
