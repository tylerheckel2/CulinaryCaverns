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

    public bool levelOne = false;
    public bool levelTwo = false;

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
        if (levelOne)
        {
            numOne = Random.Range(20, 40);
            numTwo = Random.Range(20, 40);
        }
        if (levelTwo)
        {
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
                break;
            case 2:
                if (levelOne)
                {
                    instructionText.text = "Fantastic work! Thank you so much!";
                }
                if (levelTwo)
                {
                    instructionText.text = "Great work! Thank you so much!";
                }
                break;
        }
    }

    void ProceedToNextStep()
    {
        currentStep++;
        ShowInstruction();
    }
}
