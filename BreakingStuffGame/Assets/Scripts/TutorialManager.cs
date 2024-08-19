using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI instructionText;
    private int currentStep = 0;

    public Finish finish;

    public PlayerMovement playerMovement;

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
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    ProceedToNextStep();
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space))
                    ProceedToNextStep();
                break;
            case 3:
                if (!playerMovement.IsGrounded())
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        ProceedToNextStep();
                    }
                }
                break;
            case 4:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 5:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 6:
                if (Input.GetKeyDown(KeyCode.E))
                    ProceedToNextStep();
                break;
            case 7:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 8:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 9:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 10:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
            case 11:
                if (Input.GetKeyDown(KeyCode.T))
                    ProceedToNextStep();
                break;
        }
    }

    void ShowInstruction()
    {
        switch (currentStep)
        {
            case 0:
                instructionText.text = "Hello, and welcome to Culinary Caverns! The village has found a mythical food cavern and we need your help to find food to save our population. Press T to advance to the tutorial.";
                break;
            case 1:
                instructionText.text = "Press A or D to move left or right.";
                break;
            case 2:
                instructionText.text = "Press Space to jump.";
                break;
            case 3:
                instructionText.text = "Double tap Space to double jump.";
                break;
            case 4:
                instructionText.text = "Mine dirt, purple rock, and ore blocks inside the cavern by pressing I for blocks above, K for blocks below, J for blocks to the left, and L for blocks to the right. (Press T to advance)";
                break;
            case 5:
                instructionText.text = "You can walk over the items the blocks drop to collect them. (Press T to advance)";
                break;
            case 6:
                instructionText.text = "Press E to toggle your inventory on and off to keep track of the items you have collected.";
                break;
            case 7:
                instructionText.text = "When you spawn into a level, you will be prompted with an order to collect a certain number of various food ore. (Press T to advance)";
                break;
            case 8:
                instructionText.text = "You can then enter the cavern to collect the necessary items and bring them back to the house you spawned in to advance to the next level. (Press T to advance)";
                break;
            case 9:
                instructionText.text = "You can only break blocks within the bedrock barriers of the cavern and there will be elevating platforms placed at both ends to help you navigate its depths. (Press T to advance)";
                break;
            case 10:
                instructionText.text = "Tutorial Complete! Whenever you are ready, press T to advance to the first level.";
                break;
            case 11:
                instructionText.text = "Good luck and have fun! Level 1 Loading...";
                finish.UnlockNewLevel();
                Invoke("ProceedToNextLevel", 1f);
                break;
        }
    }

    void ProceedToNextStep()
    {
        currentStep++;
        ShowInstruction();
    }

    public void ProceedToNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
