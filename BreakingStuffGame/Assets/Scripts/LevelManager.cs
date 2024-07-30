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

    public bool levelOne = false;
    public bool levelTwo = false;
    public bool levelThree = false;
    public bool levelFour = false;
    public bool levelFive = false;
    public bool levelSix = false;
    public bool levelSeven = false;

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
                if (levelOne)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected)
                        ProceedToNextStep();
                }
                if (levelTwo)
                {
                    if (playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelThree)
                {
                    if (playerInventory.numOneCollected && playerInventory.numThreeCollected)
                        ProceedToNextStep();
                }
                if (levelFour)
                {
                    if (playerInventory.numTwoCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelFive)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected)
                        ProceedToNextStep();
                }
                if (levelSix)
                {
                    if (playerInventory.numOneCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelSeven)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
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
                instructionText.text = "Great job! You have collected the necessary items. Bring them back to Sam to complete the level.";
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
