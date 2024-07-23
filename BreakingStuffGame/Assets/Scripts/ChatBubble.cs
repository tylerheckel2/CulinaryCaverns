using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;
    private Button button;
    public GameObject chatBubble;
    public int numOne;
    public int numTwo;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
        button = transform.Find("Button").GetComponent<Button>();
    }

    private void Start()
    {
        numOne = Random.Range(10, 30);
        numTwo = Random.Range(10, 30);
        Setup("Hello, welcome to our village! We need you to find us " + numOne + " numOne and " + numTwo + " numTwo.");
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
    }
}
