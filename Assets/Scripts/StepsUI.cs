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

        // Check if the current step is within the valid range
        if (currentStep >= 0 && currentStep < titleText.Length)
        {
            string nodeToPlay = GetDialogueNodeForStep(currentStep);
            float delay = GetDelayForStep(currentStep);

            // Start the coroutine for the current step
            StartCoroutine(StartDialogueAfterDelay(delay, nodeToPlay));
        }
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
            //switch (currentStep) 
            //{
            //    case 2:
            //        StartCoroutine(StartDialogueAfterDelay(5f, "Bread"));
            //        break;
            //    case 3:
            //        StartCoroutine(StartDialogueAfterDelay(5f, "Butter"));
            //        break;
            //    case 1:
            //        StartCoroutine(StartDialogueAfterDelay(10f, "Tomatoes"));
            //        break;
            //    case 4:
            //        StartCoroutine(StartDialogueAfterDelay(5f, "Basil"));
            //        break;
            //    case 5:
            //        StartCoroutine(StartDialogueAfterDelay(5f, "Mayonnaise"));
            //        break;
            //    case 6:
            //        StartCoroutine(StartDialogueAfterDelay(5f, "CompletingTheSandwich"));
            //        break;
            //}

        }
        else
        {
            currentStep = 0;
        }
    }

  

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

    //==============================================================

    private string GetDialogueNodeForStep(int step)
    {
        switch (step)
        {
            case 1: return "Bread";
            case 2: return "Butter";
            case 3: return "Mayonnaise";
            case 4: return "Tomatoes";
            case 5: return "Basil";
            case 6: return "CompletingTheSandwich";
            case 7: return "CompletingTheSandwichEmpathy";
            default: return ""; // Adjust this based on your specific logic or add additional cases
        }
    }


    private float GetDelayForStep(int step)
    {
        // Adjust the delays for each step as needed
        switch (step)
        {
            case 1: return 10f;
            case 2: return 17f;
            case 3: return 20f;
            case 4: return 20f;
            case 5: return 20f;
            case 6: return 10f;
            case 7: return 2f;
            default: return 0f; // No delay for other steps
        }
    }
}
