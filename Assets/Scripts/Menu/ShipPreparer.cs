using Assets.Scripts.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPreparer : MonoBehaviour {

    [HideInInspector]
    public Transform ship;
    
    public string DefaultShip = "none";

    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode resetKey = KeyCode.Space;

    public KeyCode SpecialKey = KeyCode.LeftShift;
    
    private void Awake()
    {
        ship = null;
        foreach(Transform child in transform)
        {
            if(child.name == GlobalVars.ShipName)
            {
                child.gameObject.SetActive(true);

                ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
                foreach(ParticleSystem system in systems)
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    system.scalingMode = ParticleSystemScalingMode.Shape;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                    system.simulationSpace = ParticleSystemSimulationSpace.World;
#pragma warning restore CS0618 // Type or member is obsolete
                }
                ship = child;
                break;
            }
        }//REMOVE LATER
        if(ship == null)
        {
            if(DefaultShip != "none")
            {
                foreach (Transform child in transform)
                {
                    if (child.name == DefaultShip)
                    {
                        child.gameObject.SetActive(true);

                        ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
                        foreach (ParticleSystem system in systems)
                        {
#pragma warning disable CS0618 // Type or member is obsolete
                            system.scalingMode = ParticleSystemScalingMode.Hierarchy;
#pragma warning restore CS0618 // Type or member is obsolete
#pragma warning disable CS0618 // Type or member is obsolete
                            system.simulationSpace = ParticleSystemSimulationSpace.World;
#pragma warning restore CS0618 // Type or member is obsolete
                        }
                        ship = child;
                        break;
                    }
                }
            }
        }
    }
}
