using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedButtons : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject nextLevelMask;

    void Start()
    {
        /*for (int i = 0; i < 6; i++)
        {
            stars[i].SetActive(false);

            Debug.Log("Deactivating star " + i);
        }

        nextLevelMask.SetActive(false);*/
    }

    public void printStars(int numberOfStars)
    {
        if (numberOfStars > 6)
            numberOfStars = 6;

        for (int i = 0; i < numberOfStars; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void printNextLevelMask(int numberOfStars)
    {
        if(numberOfStars < 3)
        {
            nextLevelMask.SetActive(true);
        }
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void selectASong()
    {

    }

}
