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
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelEight)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelNine)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelTen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numTwoCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelEleven)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numThreeCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelTwelve)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelThirteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelFourteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelFifteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelSixteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelSeventeen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelEighteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelNineteen)
        {
            if (collision.gameObject.CompareTag("Player") && !levelCompleted && (playerInventory.numOneCollected && playerInventory.numTwoCollected && playerInventory.numThreeCollected && playerInventory.numFourCollected))
            {
                levelCompleted = true;
                finishSoundEffect.Play();
                Invoke("CompleteLevel", 1.5f);
            }
        }
        if (levelTwenty)
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
