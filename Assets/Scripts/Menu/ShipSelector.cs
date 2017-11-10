using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSelector : MonoBehaviour {
    
    public List<ShipData> ShipData = new List<ShipData>();
    private int currentShip;

    public Text ShipNameText;
    public Text DescriptionText;
    public Image DriverImage;

    public void Start()
    {
        currentShip = 0;
        for (int i = 1; i < ShipData.Count; i++)
        {
            ShipData[i].ShipObject.SetActive(false);
        }
    }

    public void LastShip()
    {
        ShipData[currentShip].ShipObject.SetActive(false);

        if (currentShip >= 1)
        {
            currentShip--;
        }
        else
        {
            currentShip = ShipData.Count - 1;
        }
        UpdateShip();
    }
    public void NextShip()
    {
        ShipData[currentShip].ShipObject.SetActive(false);

        if (currentShip < ShipData.Count - 1)
        {
            currentShip++;
        }
        else
        {
            currentShip = 0;
        }
        UpdateShip();
    }

    public void UpdateShip()
    {
        ShipData data = ShipData[currentShip];

        data.ShipObject.SetActive(true);

        ShipNameText.text = data.ShipName;
        DescriptionText.text = data.Description;

        DriverImage.overrideSprite = data.DriverImage;
    }
}

[System.Serializable]
public class ShipData
{
    public GameObject ShipObject;
    public string ShipName;

    public Sprite DriverImage;

    public string Description;
}
