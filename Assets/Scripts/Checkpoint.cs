using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Checkpoint : MonoBehaviour {

    public List<Transform> PlayersPassed;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!PlayersPassed.Contains(other.transform))
        {
            PlayersPassed.Add(other.transform);
        }
    }
}