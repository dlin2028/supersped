using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ship : MonoBehaviour
{
    public ShipPreparer ShipPreparer;

    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;
    private KeyCode resetKey;

    private KeyCode specialKey;

    public float Speed = 1;

    public float TurnSpeed = 1;
    public float StopSpeed;

    public bool UseSpecialBehavior = false;

    [System.Serializable]
    public struct SpecialBehaviors
    {
        public float Speed;
        public float TurnSpeed;
        public float DriftAmount;
        public float AngularDrag;
        public float Drag;
        public float ExtraGravity;
        public float Mass;
        public PhysicMaterial PhysicMaterial;
    }

    public SpecialBehaviors SpecialBehavor = new SpecialBehaviors();

    private float normalDrag;
    private float normalAngularDrag;
    private float normalMass;
    private PhysicMaterial normalMaterial;

    private Rigidbody body;
    new private Collider collider;

    public bool fixNormals = true;
    void Start()
    {
        upKey = ShipPreparer.UpKey;
        downKey = ShipPreparer.DownKey;
        leftKey = ShipPreparer.LeftKey;
        rightKey = ShipPreparer.RightKey;
        resetKey = ShipPreparer.resetKey;
        specialKey = ShipPreparer.SpecialKey;
        
        body = GetComponent<Rigidbody>();
        collider = GetComponentInChildren<Collider>();

        normalDrag = body.drag;
        normalAngularDrag = body.angularDrag;
        normalMass = body.mass;
        normalMaterial = collider.material;
    }

    // Update is called once per frame
    //180 + (body.velocity.x / 4.5f)
    //(170 + (body.velocity.x / 3.8f))


    void FixedUpdate()
    {
        if(fixNormals)
        {
            normalDrag = body.drag;
            normalAngularDrag = body.angularDrag;
            normalMass = body.mass;
            normalMaterial = collider.material;
        }

        if (UseSpecialBehavior && Input.GetKey(specialKey))
        {
            fixNormals = false;

            body.mass = SpecialBehavor.Mass;
            
            body.drag = SpecialBehavor.Drag;
            body.angularDrag = SpecialBehavor.Drag;

            collider.material = SpecialBehavor.PhysicMaterial;

            body.AddForce(Vector3.down * SpecialBehavor.ExtraGravity);

            if (Input.GetKey(upKey))
            {
                body.AddRelativeForce(Vector3.forward * SpecialBehavor.Speed);
            }
            if (Input.GetKey(downKey))
            {
                body.drag = StopSpeed;
            }
            else
            {
                body.drag = normalDrag;
            }

            if (Input.GetKey(leftKey))
            {
                body.AddRelativeTorque(Vector3.down * SpecialBehavor.TurnSpeed);
                body.AddRelativeForce(Vector3.left * SpecialBehavor.DriftAmount * (52.5f + (295 / ((body.velocity.x) * (body.velocity.z)))));
            }
            if (Input.GetKey(rightKey))
            {
                body.AddRelativeTorque(Vector3.up * SpecialBehavor.TurnSpeed);
                body.AddRelativeForce(Vector3.right * SpecialBehavor.DriftAmount * (52.5f + (295 / ((body.velocity.x) * (body.velocity.z)))));
            }
        }
        else
        {
            if(!fixNormals)
            {
                body.drag = normalDrag;
                body.angularDrag = normalAngularDrag;
                body.mass = normalMass;
                collider.material = normalMaterial;
            }


            if (Input.GetKey(upKey))
            {
                body.AddRelativeForce(Vector3.forward * Speed);
            }
            if (Input.GetKey(downKey))
            {
                body.drag = StopSpeed;
            }
            else
            {
                body.drag = normalDrag;
            }

            if (Input.GetKey(leftKey))
            {
                body.AddRelativeTorque(Vector3.down * TurnSpeed);
            }
            if (Input.GetKey(rightKey))
            {
                body.AddRelativeTorque(Vector3.up * TurnSpeed);
            }
            fixNormals = true;
        }



        if (Input.GetKey(resetKey))
        {
            GetComponent<HUDUpdater>().FinishLine.ResetCheckPoints(transform);

            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            body.velocity = Vector2.zero;
        }
    }
}
