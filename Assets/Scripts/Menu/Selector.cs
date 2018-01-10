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
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Ship>())
            {
                child.GetComponent<Ship>().enabled = false;
                child.GetComponent<StickyRoad>().enabled = false;
                child.GetComponent<Rigidbody>().isKinematic = true;
                child.GetComponent<HUDUpdater>().enabled = false;
                child.GetComponent<AudioSource>().enabled = true;
                child.GetComponent<ConstantMovement>().enabled = true;
            }
        }

        currentShip = 0;
        for (int i = 1; i < Data.Count; i++)
        {
            Data[i].Object.SetActive(false);
        }
        UpdateData();
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
        UpdateData();
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
        UpdateData();
    }

    public void UpdateData()
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
