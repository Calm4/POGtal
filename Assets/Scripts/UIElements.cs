// UIElements.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIElements : MonoBehaviour
{
    private bool dash = true;
    public TextMeshProUGUI dashText;
    public Image dashImage;
    public Sprite dashImageOff;
    public Sprite dashImageOn;

    void Start()
    {
        //dashImage = dashImageOn;
        UpdateUI();
    }

    void Update()
    {

    }

    public void UpdateUI()
    {
        dash = !dash;
        string dashStatus = dash ? "перезаряжается" : "готов";
        dashText.text = "Рывок " + dashStatus;
        dashImage.sprite = dash ? dashImageOff : dashImageOn;
    }
}