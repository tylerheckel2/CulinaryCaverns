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

    public TextMeshPro instructionText;
    private int currentStep = 0;

    public PlayerInventory playerInventory;

    public Finish finish;

    public bool rarerLevel = false;
    public bool levelOne = false;
    public bool levelTwo = false;
    public bool levelThree = false;
    public bool levelFour = false;
    public bool levelFive = false;
    public bool levelSix = false;
    public bool levelSeven = false;

    /*private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
        button = transform.Find("Button").GetComponent<Button>();
    }*/

    /*private void Start()
    {
        numOne = Random.Range(10, 30);
        numTwo = Random.Range(10, 30);
        Setup("Hello, welcome to our village! We need you to find us " + numOne + " numOne and " + numTwo + " numTwo.");
    }*/

    /*private void Setup(string text)
    {
        textMeshPro.SetText(text);
    }*/

    void Start()
    {
        if (rarerLevel)
        {
            numOne = Random.Range(15, 25);
            numTwo = Random.Range(15, 25);
            numThree = Random.Range(15, 25);
            numFour = Random.Range(15, 25);
        }
        else
        {
            numOne = Random.Range(20, 40);
            numTwo = Random.Range(20, 40);
            numThree = Random.Range(20, 40);
            numFour = Random.Range(20, 40);
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
                instructionText.text = "Press T to Talk.";
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
                    instructionText.text = "Hello again! This time we need you to find us " + numOne + " Burgers, " + numTwo + " Ice Cream Cones, " + numThree + " Sushi, and " + numFour + " Smoothies.";
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
