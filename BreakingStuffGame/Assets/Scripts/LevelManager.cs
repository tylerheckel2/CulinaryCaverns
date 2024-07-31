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
    public bool levelEight = false;
    public bool levelNine = false;
    public bool levelTen = false;
    public bool levelEleven = false;
    public bool levelTwelve = false;
    public bool levelThirteen = false;
    public bool levelFourteen = false;
    public bool levelFifteen = false;
    public bool levelSixteen = false;
    public bool levelSeventeen = false;
    public bool levelEighteen = false;
    public bool levelNineteen = false;
    public bool levelTwenty = false;

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
                    if (playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelEight)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelNine)
                {
                    if (playerInventory.numOneCollected)
                        ProceedToNextStep();
                }
                if (levelTen)
                {
                    if (playerInventory.numTwoCollected)
                        ProceedToNextStep();
                }
                if (levelEleven)
                {
                    if (playerInventory.numThreeCollected)
                        ProceedToNextStep();
                }
                if (levelTwelve)
                {
                    if (playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelThirteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelFourteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected)
                        ProceedToNextStep();
                }
                if (levelFifteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelSixteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected)
                        ProceedToNextStep();
                }
                if (levelSeventeen)
                {
                    if (playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelEighteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelNineteen)
                {
                    if (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected)
                        ProceedToNextStep();
                }
                if (levelTwenty)
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
