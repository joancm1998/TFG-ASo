using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool hasStarted;

    //Score
    public int maxScore = 100;
    public float currentScore = 2f;
    public int totalNotes;

    public Image scoreBarContent;

    public GameObject screenNotes;

    private int doneNote = 0;


    //Screens
    public GameObject pianoUI;
    public GameObject scoreBarUI;
    public GameObject completedLevelUI;

    //Music
    public AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        hasStarted = false;

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

        //song.Play();
        //song.pitch = 0.5f
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            Debug.Log(Input.touchCount);
            if(Input.touchCount > 0)
            {
                hasStarted = true;
                screenNotes.GetComponent<NoteScroller>().hasStarted = true;
                song.Play();
            }
        }
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
        

        currentScore += (float) maxScore / (float) totalNotes;
        Debug.Log("CORRECT! Current score:" + currentScore);
        if (currentScore>maxScore)
        {
            currentScore = maxScore;
        }
        updateScoreBar();
    }

    public void failNote()
    {


        currentScore -= (float)maxScore / (float)totalNotes;
        Debug.Log("FAIL! Current score:" + currentScore);
        if (currentScore < 0)
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

        if (currentScore > 99.5f)
        {
            numberOfStars = 6;
        }

        return numberOfStars;
    }
}
