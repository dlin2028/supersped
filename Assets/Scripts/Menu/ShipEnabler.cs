using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnabler : MonoBehaviour {

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            if(child.name == ScenePreparer.ShipName)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
