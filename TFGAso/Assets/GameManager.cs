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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
