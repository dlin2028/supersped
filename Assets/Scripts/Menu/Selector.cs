using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {
    
    public List<ItemData> Data = new List<ItemData>();
    private int currentShip;

    public Text NameText;
    public Text DescriptionText;
    public Image Image;

    public void Start()
    {
        currentShip = 0;
        for (int i = 1; i < Data.Count; i++)
        {
            Data[i].Object.SetActive(false);
        }
        UpdateShip();
    }

    public void Previous()
    {
        Data[currentShip].Object.SetActive(false);

        if (currentShip >= 1)
        {
            currentShip--;
        }
        else
        {
            currentShip = Data.Count - 1;
        }
        UpdateShip();
    }
    public void Next()
    {
        Data[currentShip].Object.SetActive(false);

        if (currentShip < Data.Count - 1)
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
        ItemData data = Data[currentShip];

        data.Object.SetActive(true);

        NameText.text = data.Object.name;
        DescriptionText.text = data.Description;

        Image.overrideSprite = data.Image;
    }
}

[System.Serializable]
public class ItemData
{
    public GameObject Object;

    public Sprite Image;

    public string Description;
}
