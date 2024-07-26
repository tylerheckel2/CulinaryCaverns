using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    private int currentStep = 0;

    public PlayerInventory playerInventory;
    public ChatBubble chatBubble;
    public Finish finish;

    void Start()
    {
        ShowInstruction();
    }

    void Update()
    {
        switch (currentStep)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 1:
                if (playerInventory.numOneCollected && playerInventory.numTwoCollected)
                    ProceedToNextStep();
                break;
            case 2:
                if(finish.levelCompleted)
                {
                    ProceedToNextStep();
                }
                break;
            case 3:
                break;
        }
    }

    void ShowInstruction()
    {
        switch (currentStep)
        {
            case 0:
                instructionText.text = "Talk to Sam.";
                break;
            case 1:
                instructionText.text = "Enter the cavern to your right to find and collect the requested items.";
                break;
            case 2:
                instructionText.text = "Great job! You have collected the necessary items. Bring them back to Sam to advance to the next level.";
                break;
            case 3:
                instructionText.text = "Level Complete!";
                break;
        }
    }

    void ProceedToNextStep()
    {
        currentStep++;
        ShowInstruction();
    }
}
