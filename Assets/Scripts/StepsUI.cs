using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class StepsUI : MonoBehaviour
{
    public TextMeshProUGUI tileTextMeshPro;
    public TextMeshProUGUI descriptionTextMeshPro;
    public DialogueRunner dialogueRunner;

    public string[] titleText;
    public string[] descriptionText;

    private int currentStep = 0;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindAnyObjectByType<DialogueRunner>();
        UpdateUI();
    }

    public void NextButtonAction()
    {
        currentStep++;
        UpdateUI();
    }

    IEnumerator StartDialogueAfterDelay(float delay, string nodeToPlay)
    {
        yield return new WaitForSeconds(delay);
        dialogueRunner.StartDialogue(nodeToPlay);
    }
    public void UpdateUI()
    {
        if(currentStep >= 0 && currentStep < titleText.Length)
        {
            tileTextMeshPro.text = titleText[currentStep];
            descriptionTextMeshPro.text = descriptionText[currentStep];
            //descriptionTextMeshPro.text = FormatDescriptionText(descriptionText[currentStep]);
            switch (currentStep) 
            {
                case 2:
                    StartCoroutine(StartDialogueAfterDelay(5f, "Bread"));
                    break;
                case 3:
                    StartCoroutine(StartDialogueAfterDelay(5f, "Butter"));
                    break;
                case 1:
                    StartCoroutine(StartDialogueAfterDelay(10f, "Tomatoes"));
                    break;
                case 4:
                    StartCoroutine(StartDialogueAfterDelay(5f, "Basil"));
                    break;
                case 5:
                    StartCoroutine(StartDialogueAfterDelay(5f, "Mayonnaise"));
                    break;
                case 6:
                    StartCoroutine(StartDialogueAfterDelay(5f, "CompletingTheSandwich"));
                    break;
            }

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
