using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Range(0, 1000)]
    public float Speed = 1;
    [Range(0, 1000)]
    public float TurnSpeed = 1;
    [Range(0, 500)]
    public float StopSpeed;
    [Range(0, 500)]
    public float TurboSpeed;
    [Range(0, 500)]
    public float SlowTurnSpeed;
    [Range(0, 500)]
    public float SlowTurnDrag;


    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode resetKey = KeyCode.Space;

    public KeyCode TurboKey = KeyCode.LeftShift;
    public KeyCode TurnSlowKey = KeyCode.LeftControl;

    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    //180 + (body.velocity.x / 4.5f)
    //(170 + (body.velocity.x / 3.8f))

    void FixedUpdate()
    {

        if (Input.GetKey(UpKey))
        {
            if (Input.GetKey(TurboKey))
            {
                body.AddRelativeForce(Vector3.forward * TurboSpeed);
            }
            body.AddRelativeForce(Vector3.forward * Speed);
        }
        if (Input.GetKey(DownKey))
        {
            body.drag = StopSpeed;
        }
        else
        {
            body.drag = 2f;
        }


        if (Input.GetKey(TurnSlowKey))
        {

            body.drag = SlowTurnDrag;
            body.AddRelativeForce(Vector3.forward * Speed * -0.5f);
            if (Input.GetKey(LeftKey))
            {
                body.AddRelativeForce(Vector3.right * (50 + (300 / ((body.velocity.x) * (body.velocity.z)))));
                body.AddRelativeTorque(Vector3.down * TurnSpeed * 1.5f);
            }
            if (Input.GetKey(RightKey))
            {
                body.AddRelativeForce(Vector3.left * (50 + (300 / ((body.velocity.x) * (body.velocity.z)))));
                body.AddRelativeTorque(Vector3.up * TurnSpeed * 1.5f);
            }
        }
        else
        {
            body.angularDrag = 6f;
            if (Input.GetKey(LeftKey))
            {
                body.AddRelativeTorque(Vector3.down * TurnSpeed);
            }
            if (Input.GetKey(RightKey))
            {
                body.AddRelativeTorque(Vector3.up * TurnSpeed);
            }
        }


        if (Input.GetKey(resetKey))
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            body.velocity = Vector2.zero;
        }
    }
}
