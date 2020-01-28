using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInformation : MonoBehaviour
{

    public int levelNumber;
    public GameObject levelNumberGO;
    public string levelName;
    public GameObject levelNameGO;
    public int levelScore;
    public GameObject[] levelScoreGO;

    public int levelScore1;
    public int levelScore2;
    public int levelScore3;
    public int levelScore4;
    public int levelScore5;




    // Start is called before the first frame update
    void Start()
    {
        printInformation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printStars(int numberOfStars)
    {
        //treat data
        if (numberOfStars > 6)
            numberOfStars = 6;

        if (numberOfStars < 0)
            numberOfStars = 0;

        

        for (int i = 0; i < numberOfStars; i++)
        {
            levelScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }


    }

    public void setInformation(int number, string name, int score1, int score2, int score3, int score4, int score5)
    {
        levelNumber = number;
        levelName = name;
        levelScore1 = LoadSaveManager.instance.loadLevelScore(name, 1);
        levelScore2 = LoadSaveManager.instance.loadLevelScore(name, 2);
        levelScore3 = LoadSaveManager.instance.loadLevelScore(name, 3);
        levelScore4 = LoadSaveManager.instance.loadLevelScore(name, 4);
        levelScore5 = LoadSaveManager.instance.loadLevelScore(name, 5);

        levelScore = (levelScore1 + levelScore2 + levelScore3 + levelScore4 + levelScore5) /5;
        /*levelScore1 = score1;
        levelScore2 = score2;
        levelScore3 = score3;
        levelScore4 = score4;
        levelScore5 = score5;*/
        printInformation();
    }

    public void printInformation()
    {
        levelNumberGO.GetComponent<Text>().text = levelNumber.ToString();
        levelNameGO.GetComponent<Text>().text = levelName;
        printStars(levelScore);
    }

    public void selectSong()
    {
        SongSelectionButtons.instance.selectSong(levelNumber, levelName, levelScore, levelScore1, levelScore2, levelScore3, levelScore4, levelScore5);
        Debug.Log("Selected song: " + levelNumber + levelName + levelScore);
    }
}
