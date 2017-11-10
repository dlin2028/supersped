using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Transform ShipParent;

    public List<Collider> PlayerColliders = new List<Collider>();

    [HideInInspector]
    public List<PlayerData> playerData = new List<PlayerData>();

    public List<Checkpoint> CheckPoints;

    private void Awake()
    {
        foreach (Transform child in ShipParent)
        {
            PlayerColliders.Add(child.GetComponentInChildren<Collider>());
        }

        for (int i = 0; i < PlayerColliders.Count; i++)
        {
            playerData.Add(new PlayerData(PlayerColliders[i].transform));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UpdateCheckPoints(other.transform);
    }

    private void Update()
    {
        foreach (PlayerData player in playerData)
        {
            player.CurrentTime += new TimeSpan(0, 0, 0, (int)Math.Round(Time.deltaTime * 1000, 0));
        }
    }

    private void UpdateCheckPoints(Transform player)
    {
        bool finish = true;
        for (int i = 0; i < CheckPoints.Count; i++)
        {
            if (!CheckPoints[i].PlayersPassed.Contains(player))
            {
                finish = false;
                break;
            }
        }

        if (finish)
        {
            for (int i = 0; i < CheckPoints.Count; i++)
            {
                CheckPoints[i].PlayersPassed.Remove(player);
            }

            for (int i = 0; i < playerData.Count; i++)
            {
                if (playerData[i].Transform == player)
                {
                    if (playerData[i].BestTime > playerData[i].CurrentTime)
                    {
                        playerData[i].BestTime = playerData[i].CurrentTime;
                    }

                    playerData[i].CurrentTime = TimeSpan.Zero;
                    playerData[i].Laps++;
                }
            }
        }

    }
}

public class PlayerData
{
    public Transform Transform;
    public TimeSpan CurrentTime;
    public TimeSpan BestTime;
    public int Laps;

    public PlayerData(Transform transform)
    {
        Transform = transform;
        BestTime = TimeSpan.MaxValue;
        CurrentTime = TimeSpan.Zero;
        Laps = 0;
    }
}
