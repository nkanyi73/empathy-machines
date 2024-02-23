using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StepsUI : MonoBehaviour
{
    public TextMeshProUGUI tileTextMeshPro;
    public TextMeshProUGUI descriptionTextMeshPro;

    public string[] titleText;
    public string[] descriptionText;

    private int currentStep = 0;


    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    public void NextButtonAction()
    {
        currentStep++;
        UpdateUI();
    }
    public void UpdateUI()
    {
        if(currentStep >= 0 && currentStep < titleText.Length)
        {
            tileTextMeshPro.text = titleText[currentStep];
            descriptionTextMeshPro.text = descriptionText[currentStep];
            //descriptionTextMeshPro.text = FormatDescriptionText(descriptionText[currentStep]);

        }
        else
        {
            currentStep = 0;
        }
    }

    //private string FormatDescriptionText(string description)
    //{
    //    // Add bullet points using rich text formatting
    //    return $"<b>Bullet Points:</b>\n• {description.Replace("\n", "\n• ")}";
    //}

    private string FormatDescriptionText(string description)
    {
        // Split the description into lines
        string[] lines = description.Split('\n');

        // Add bullet points using rich text formatting
        string formattedText = "<b>Bullet Points:</b>\n";

        for (int i = 0; i < lines.Length; i++)
        {
            formattedText += $"• {lines[i]}\n";
        }

        return formattedText;
    }
}
