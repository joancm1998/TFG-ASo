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
        if (numberOfStars > 6)
            numberOfStars = 6;

        for (int i = 0; i < numberOfStars; i++)
        {
            levelScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void setInformation(int number, string name, int score)
    {
        levelNumber = number;
        levelName = name;
        levelScore = score;
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
        SongSelectionButtons.instance.selectSong(levelNumber, levelName, levelScore);
        Debug.Log("Selected song: " + levelNumber + levelName + levelScore);
    }
}
