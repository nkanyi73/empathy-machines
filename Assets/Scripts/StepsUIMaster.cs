using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class StepsUIMaster : MonoBehaviour
{
    public TextMeshProUGUI tileTextMeshPro;
    public TextMeshProUGUI descriptionTextMeshPro;
    public DialogueRunner dialogueRunner;

    public string[] titleText;
    public string[] descriptionText;

    private int currentStep = 10;
    private float startTime;

    public GameObject nextSceneButton;
    public GameObject nextButton;

    public EnvironmentScript env;
    public AirtableManager airtableManager;

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
            case 16:
                nextSceneButton.SetActive(true);
                nextButton.SetActive(false);
                AirtableManager.twoHandedDuration = env.StopCounter().ToString();
                airtableManager.CreateRecord();
                return "";
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
