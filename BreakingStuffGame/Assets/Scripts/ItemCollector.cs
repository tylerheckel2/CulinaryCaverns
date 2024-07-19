using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int numOne = 0;
    public int numTwo = 0;

    private TileDropController tileDrop;
    public PlayerInventory playerInventory;

    [SerializeField] public Text numOneText;
    [SerializeField] public Text numTwoText;

    private void Start()
    {
        /*NumOneCollector();*/
    }
    //[SerializeField] private AudioSource collectionSoundEffect;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
            //collectionSoundEffect.Play();
            numOne++;
            numOneText.text = "NumOne: " + numOne;

        if (collision.gameObject.CompareTag("Pineapple"))
        {
            //collectionSoundEffect.Play();
            numTwo++;
            numTwoText.text = "NumTwo: " + numTwo;
        }
    }*/
    public void NumOneCollector()
    {
        numOne++;
        numOneText.text = "Num One: " + numOne;
    }

    public void NumTwoCollector()
    {
        numTwo++;
        numTwoText.text = "NumTwo: " + numTwo;
    }
}
