using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveManager : MonoBehaviour
{
    public static LoadSaveManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void saveLevelScore(string song, int level, int points)
    {
        if (points > loadLevelScore(song, level))
        {
            Debug.Log("Saving score - song: " + song + " level: " + level + " points: " + points);
            PlayerPrefs.SetInt(string.Concat(song, level.ToString()), points);
        }
        
    }

    public int loadLevelScore(string song, int level)
    {
        int points = PlayerPrefs.GetInt(string.Concat(song, level.ToString()), 0);
        Debug.Log("Loading score - song: " + song + " level: " + level + " points: " + points);
        return points;
    }

    public void resetScores()
    {
        PlayerPrefs.DeleteAll();
    }
}
