using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    public int numOne;
    public int numTwo;
    public int numThree;
    public int numFour;
    public int totalFood = 0;

    public TextMeshPro instructionText;
    private int currentStep = 0;

    public PlayerInventory playerInventory;

    public Finish finish;

    public bool rarerLevel = false;
    public bool evenRarerLevel = false;
    public bool bonusLevelOne = false;
    public bool bonusLevelTwo = false;
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
    public bool levelTwentyOne = false;
    public bool levelTwentyTwo = false;

    void Start()
    {
        if (bonusLevelOne)
        {
            totalFood = 350;
        }
        else if (bonusLevelTwo)
        {
            totalFood = 400;
        }
        if (evenRarerLevel)
        {
            numOne = Random.Range(12, 14);
            numTwo = Random.Range(12, 14);
            numThree = Random.Range(12, 14);
            numFour = Random.Range(12, 14);
        }
        else if (rarerLevel)
        {
            numOne = Random.Range(20, 24);
            numTwo = Random.Range(20, 24);
            numThree = Random.Range(20, 24);
            numFour = Random.Range(20, 24);
        }
        else
        {
            numOne = Random.Range(25, 36);
            numTwo = Random.Range(25, 36);
            numThree = Random.Range(25, 36);
            numFour = Random.Range(25, 36);
        }
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
                if (finish.levelCompleted)
                    ProceedToNextStep();
                break;
            case 2:
                break;
        }
    }

    void ShowInstruction()
    {
        switch (currentStep)
        {
            case 0:
                instructionText.text = "Press  <sprite name=\"keycaps_for_tutorial_export_updated_1\">  to Talk.";
                break;
            case 1:
                if (levelOne)
                {
                    instructionText.text = "Hello, I'm Sam. Welcome to our village! We need you to find us " + numOne + " Burgers and " + numTwo + " Ice Cream Cones.";
                }
                if (levelTwo)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numThree + " Sushi and " + numFour + " Smoothies.";
                }
                if (levelThree)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers and " + numThree + " Sushi.";
                }
                if (levelFour)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numTwo + " Ice Cream Cones and " + numFour + " Smoothies.";
                }
                if (levelFive)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, and " + numThree + " Sushi.";
                }
                if (levelSix)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelSeven)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelEight)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, "+ numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelNine)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers.";
                }
                if (levelTen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numTwo + " Ice Cream Cones.";
                }
                if (levelEleven)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numThree + " Sushi.";
                }
                if (levelTwelve)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numFour + " Smoothies.";
                }
                if (levelThirteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers and " + numFour + " Smoothies.";
                }
                if (levelFourteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers and " + numTwo + " Ice Cream Cones.";
                }
                if (levelFifteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelSixteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, and " + numThree + " Sushi.";
                }
                if (levelSeventeen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelEighteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, and " + numFour + " Smoothies.";
                }
                if (levelNineteen)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies."; ;
                }
                if (levelTwenty)
                {
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
                }
                if (levelTwentyOne)
                {
                    instructionText.text = "Hello! In this Bonus Level we want you to find us " + totalFood + " Total Food Items.";
                }
                if (levelTwentyTwo)
                {
                    instructionText.text = "Hello! In this Bonus Level we want you to find us " + totalFood + " Total Food Items."; ;
                }
                break;
            case 2:
                instructionText.text = "Fantastic work! Thank you so much!";
                break;
        }
    }

    void ProceedToNextStep()
    {
        currentStep++;
        ShowInstruction();
    }
}
