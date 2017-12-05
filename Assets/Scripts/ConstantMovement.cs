using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour {

    public Vector3 Movement;
    public Vector3 Rotation;

    public bool FixCenter = true;


    private void Start()
    {
        if(FixCenter)
        {
            MeshRenderer rend = GetComponentInChildren<MeshRenderer>();
            Transform child = rend.transform;
            child.position = child.TransformPoint(rend.bounds.center);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Rotate(Rotation);
        transform.position += Movement;
	}
}
