using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPreparer : MonoBehaviour {

    [HideInInspector]
    public Transform ship;

    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode resetKey = KeyCode.Space;

    public KeyCode SpecialKey = KeyCode.LeftShift;
    
    private void Awake()
    {
        foreach(Transform child in transform)
        {
            if(child.name == ScenePreparer.ShipName)
            {
                child.gameObject.SetActive(true);
                ship = child;
                break;
            }
        }
    }
}
