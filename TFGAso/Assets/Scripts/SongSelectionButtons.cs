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


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        songSelectionUI.SetActive(true);
        selectedSongUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSong(int number, string name, int score)
    {
        songNumberGO.GetComponent<Text>().text = number.ToString();
        songNameGO.GetComponent<Text>().text = name;
        songName = name;

        for (int i = 0; i < score; i++)
        {
            songScoreGO[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }

        difficulty = "EASY";

        songSelectionUI.SetActive(false);
        selectedSongUI.SetActive(true);
    }

    public void selectLevel(string level)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        string levelName = "Scenes/" + difficulty + "/" + songName + "/" + level;
        SceneManager.LoadScene(levelName);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
        
    }
}
