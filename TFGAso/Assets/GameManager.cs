﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public GameObject character;
    public bool hasCharacter;

    //Screens
    public GameObject pianoUI;
    public GameObject scoreBarUI;
    public GameObject completedLevelUI;

    public GameObject pauseButton;

    //Clouds
    public GameObject clouds;
    public bool hasClouds = false;

    //Music
    public AudioSource song;

    //Title init
    public GameObject levelInformation;

    //Note bar
    public GameObject noteBar;
    public bool hasNoteBar = false;


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

        levelInformation.transform.GetChild(0).GetComponent<Text>().text = song.name.ToUpper();
        levelInformation.transform.GetChild(1).GetComponent<Text>().text = SceneManager.GetActiveScene().name.ToUpper();

        if (SceneManager.GetActiveScene().name != "Presentation")
        {
            completedLevelUI.SetActive(false);
            scoreBarUI.SetActive(true);
        }


        
        pianoUI.SetActive(true);
        

        if(hasClouds)
        {
            clouds.SetActive(false);
        }
        
        

        Debug.Log("Length of the song is: " + song.clip.length);

        pauseButton.SetActive(false);
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

                levelInformation.GetComponent<Animator>().enabled = true;

                pauseButton.SetActive(true);

                if(hasClouds)
                {
                    clouds.SetActive(true);
                    clouds.GetComponent<Animator>().enabled = true;
                }

                if(hasCharacter)
                {
                    character.GetComponent<CharacterMovement>().isActive = true;
                }
            }
        }
    }

    public void didNote()
    {
        doneNote++;

        Debug.Log("hit notes: " + doneNote);
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

        if(hasNoteBar)
        {
            noteBar.GetComponent<Animator>().Play("NoteCorrect",-1,0);
            //noteBar.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
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
        
        if (hasNoteBar)
        {
            noteBar.GetComponent<Animator>().Play("NoteFail", -1, 0);
            //noteBar.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
    }

    public void updateScoreBar()
    {
        scoreBarContent.GetComponent<Image>().fillAmount = (currentScore / 100f);
    }

    public void finishLevel()
    {
        /*if (SceneManager.GetActiveScene().name == "Presentation")
        {
            
        }*/

        pauseButton.SetActive(false);
        pianoUI.SetActive(false);
        completedLevelUI.SetActive(true);


        if (SceneManager.GetActiveScene().name != "Presentation")
        {

            
            scoreBarUI.SetActive(false);
            Debug.Log("Level finished with a total score of " + currentScore + "%. Congratulations!!");


            completedLevelUI.GetComponent<LevelCompletedButtons>().printStars(getStarScore());
            completedLevelUI.GetComponent<LevelCompletedButtons>().printNextLevelMask(getStarScore());

            Debug.Log("stars to print :" + getStarScore());



            LoadSaveManager.instance.saveLevelScore(song.name.ToUpper(), int.Parse(SceneManager.GetActiveScene().name.Split(' ')[1]), getStarScore());
        }
        else
        {
            /*if (SceneToScene.targetScene > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + SceneToScene.targetScene);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }*/
        }
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

    /*public void saveLevelScore(string song, int level, int points)
    {
        Debug.Log("try with " + song + level + points);
        PlayerPrefs.SetInt(string.Concat(song, level.ToString()), points);
    }

    public int loadLevelScore(string song, int level)
    {
        return PlayerPrefs.GetInt(string.Concat(song, level.ToString()), 0);
    }*/
}
