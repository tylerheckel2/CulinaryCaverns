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

    public TextMeshPro instructionText;
    private int currentStep = 0;

    public PlayerInventory playerInventory;

    public Finish finish;

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
        numOne = Random.Range(20, 40);
        numTwo = Random.Range(20, 40);
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
                instructionText.text = "Hello, I'm Sam. Welcome to our village! We need you to find us " + numOne + " Burgers and " + numTwo + " Ice Cream Cones.";
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
