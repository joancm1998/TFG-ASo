using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxScore = 100;
    public int currentScore = 2;
    public int totalNotes;

    public Image scoreBarContent;

    public GameObject screenNotes;

    private int doneNote = 0;

    public GameObject pianoUI;
    public GameObject scoreBarUI;
    public GameObject completedLevelUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (maxScore == 0)
        {
            maxScore = 100;
        }

        if (totalNotes == 0)
        {
            totalNotes = screenNotes.transform.childCount;
        }

        completedLevelUI.SetActive(false);
        pianoUI.SetActive(true);
        scoreBarUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void didNote()
    {
        doneNote++;

        if(doneNote == totalNotes)
        {
            finishLevel();
        }
    }

    public void correctNote()
    {


        currentScore += maxScore / totalNotes;

        if(currentScore>maxScore)
        {
            currentScore = maxScore;
        }
        updateScoreBar();
    }

    public void failNote()
    {
        currentScore -= maxScore / totalNotes;
 
        if(currentScore < 0)
        {
            currentScore = 0;
        }

        updateScoreBar();
    }

    public void updateScoreBar()
    {
        scoreBarContent.GetComponent<Image>().fillAmount = (currentScore / 100f);
    }

    public void finishLevel()
    {
        Debug.Log("Level finished with a total score of " + currentScore + "%. Congratulations!!");

        completedLevelUI.SetActive(true);
        completedLevelUI.GetComponent<LevelCompletedButtons>().printStars(getStarScore());
        completedLevelUI.GetComponent<LevelCompletedButtons>().printNextLevelMask(getStarScore());

        Debug.Log("stars to print :" + getStarScore());

        pianoUI.SetActive(false);
        scoreBarUI.SetActive(false);

    }

    public int getStarScore()
    {
        int numberOfStars = 0;
        float auxScore = currentScore;

        while( (auxScore - (maxScore/6f)) >= 0 )
        {
            auxScore = (auxScore - (maxScore / 6f));
            numberOfStars++;
        }

        return numberOfStars;
    }
}
