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

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (maxScore == 0)
        {
            maxScore = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void correctNote()
    {
        currentScore += maxScore / totalNotes;
        scoreBarContent.GetComponent<Image>().fillAmount = (currentScore / 100f);
        //scoreBarContent.GetComponent<Image>().fillAmount = 0.5f;
    }
}
