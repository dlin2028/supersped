using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUpdater : MonoBehaviour {

    public FinishLine FinishLine;

    public Text Text;

    private PlayerData data;

    private void Start()
    {
        for (int i = 0; i < FinishLine.playerData.Count; i++)
        {
            if(FinishLine.playerData[i].Transform == GetComponentInChildren<Collider>().transform)
            {
                data = FinishLine.playerData[i];
                break;
            }
        }
    }

    void Update () {
        Text.text = "Time: " + data.CurrentTime.ToString() + "\nLap: " + data.Laps.ToString() + "\nBest Lap: " + data.BestTime;
	}
}
