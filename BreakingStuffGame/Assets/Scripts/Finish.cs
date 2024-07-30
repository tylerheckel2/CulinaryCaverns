using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public AudioSource finishSoundEffect;

    public bool levelCompleted = false;
    public bool levelOne = false;
    public bool levelTwo = false;
    public bool levelThree = false;
    public bool levelFour = false;
    public bool levelFive = false;
    public bool levelSix = false;
    public bool levelSeven = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelOne)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelTwo)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelThree)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numThreeCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelFour)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numTwoCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelFive)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelSix)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelSeven)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
