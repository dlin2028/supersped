using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Range(0, 500)]
    public float Speed = 1;
    [Range(0, 500)]
    public float TurnSpeed = 1;
    [Range(0, 500)]
    public float StopSpeed;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode resetKey = KeyCode.Space;

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(UpKey))
        {
            body.AddRelativeForce(Vector3.forward * Speed);
        }
        if (Input.GetKey(DownKey))
        {
            body.drag = StopSpeed;
        }
        else
        {
            body.drag = 1;
        }
        if (Input.GetKey(LeftKey))
        {
            body.AddRelativeTorque(Vector3.down * TurnSpeed);
        }
        if (Input.GetKey(RightKey))
        {
            body.AddRelativeTorque(Vector3.up * TurnSpeed);
        }
        if(Input.GetKey(resetKey))
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            body.velocity = Vector2.zero;
        }
    }
}
