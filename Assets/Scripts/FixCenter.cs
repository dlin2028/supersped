using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCenter : MonoBehaviour {
	void Start ()
    {
        MeshRenderer rend = GetComponentInChildren<MeshRenderer>();
        Transform child = rend.transform;

        child.localPosition = Vector3.zero;
        child.localPosition -= transform.InverseTransformPoint(rend.bounds.center);
    }

    //REMOVE LATER
    private void Update()
    {
        MeshRenderer rend = GetComponentInChildren<MeshRenderer>();
        Transform child = rend.transform;

        child.localPosition = Vector3.zero;
        child.localPosition -= transform.InverseTransformPoint(rend.bounds.center);
    }
}
