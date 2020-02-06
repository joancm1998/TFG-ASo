using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongSelectionButtons : MonoBehaviour
{
    public static SongSelectionButtons instance;

    public static int songNumber;
    public GameObject songNumberGO;
    public static string songName;
    public GameObject songNameGO;
    public static int songScore;
    public GameObject[] songScoreGO;

    public static string difficulty;

    public GameObject songSelectionUI;
    public GameObject selectedSongUI;



    public int level1Score;
    public GameObject[] level1ScoreGO;
    public int level2Score;
    public GameObject[] level2ScoreGO;
    public int level3Score;
    public GameObject[] level3ScoreGO;
    public int level4Score;
    public GameObject[] level4ScoreGO;
    public int level5Score;
    public GameObject[] level5ScoreGO;

    public GameObject[] levelButtons;

    public string[] groupsOfSongs;
    public int currentGroup;
    public int numberOfGroups;
    public GameObject levels;

    public GameObject songsParent;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        songSelectionUI.SetActive(true);
        selectedSongUI.SetActive(false);


        resetInfo();

        currentGroup = 0;
        levels.GetComponent<LevelsSetUp>().setLevelsInformationAndroid(groupsOfSongs[currentGroup]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSong(int number, string name, int score, int stars1, int stars2, int stars3, int stars4, int stars5)
    {

        resetInfo();

        

        songNumberGO.GetComponent<Text>().text = number.ToString();
        songNameGO.GetComponent<Text>().text = name;
        songName = name;

        for (int i = 0; i < score; i++)
        {
            songScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }


        if (stars1 > 6)
            stars1 = 6;

        if (stars1 < 0)
            stars1 = 0;

        if (stars2 > 6)
            stars2 = 6;

        if (stars2 < 0)
            stars2 = 0;

        if (stars3 > 6)
            stars3 = 6;

        if (stars3 < 0)
            stars3 = 0;

        if (stars4 > 6)
            stars4 = 6;

        if (stars4 < 0)
            stars4 = 0;

        if (stars5 > 6)
            stars5 = 6;

        if (stars5 < 0)
            stars5 = 0;

        Debug.Log("This song has scores of: " + stars1 + stars2 + stars3 + stars4 + stars5);

        for (int i = 0; i < stars1; i++)
        {
            level1ScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        if (stars1 < 3)
        {
            levelButtons[1].GetComponent<Button>().interactable = false;
        }
        else
        {
            levelButtons[1].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < stars2; i++)
        {
            level2ScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        if (stars2 < 3)
        {
            levelButtons[2].GetComponent<Button>().interactable = false;
        }
        else
        {
            levelButtons[2].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < stars3; i++)
        {
            level3ScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        if (stars3 < 3)
        {
            levelButtons[3].GetComponent<Button>().interactable = false;
        }
        else
        {
            levelButtons[3].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < stars4; i++)
        {
            level4ScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        if (stars4 < 3)
        {
            levelButtons[4].GetComponent<Button>().interactable = false;
        }
        else
        {
            levelButtons[4].GetComponent<Button>().interactable = true;
        }

        for (int i = 0; i < stars5; i++)
        {
            level5ScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }


        difficulty = "EASY";

        songSelectionUI.SetActive(false);
        selectedSongUI.SetActive(true);
    }

    public void selectLevel(int level)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //string levelName = "Scenes/" + difficulty + "/" + songName + "/" + level;
        SceneToScene.targetScene = level;
        SceneToScene.songNumber = songNumber;
        SceneManager.LoadScene("Presentation");
    }

    public void back()
    {
        if (selectedSongUI.activeInHierarchy)
        {
            songSelectionUI.SetActive(true);
            selectedSongUI.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
            
        
    }

    public void resetInfo()
    {

        for (int i = 0; i < 6; i++)
        {
            songScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }

        for (int i = 0; i < 6; i++)
        {
            level1ScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }

        for (int i = 0; i < 6; i++)
        {
            level2ScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }

        for (int i = 0; i < 6; i++)
        {
            level3ScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }

        for (int i = 0; i < 6; i++)
        {
            level4ScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }

        for (int i = 0; i < 6; i++)
        {
            level5ScoreGO[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
    }

    public void changeGroup(bool next)
    {
        if(next)
        {
            currentGroup++;

            if (currentGroup == numberOfGroups)
            {
                currentGroup = 0;
            }

            resetInfo();
            levels.GetComponent<LevelsSetUp>().setLevelsInformationAndroid(groupsOfSongs[currentGroup]);
        }
        else
        {

            currentGroup--;

            if(currentGroup < 0)
            {
                currentGroup = numberOfGroups - 1;
            }

            resetInfo();
            levels.GetComponent<LevelsSetUp>().setLevelsInformationAndroid(groupsOfSongs[currentGroup]);
           
            
        }
    }
}
