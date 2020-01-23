using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class LevelsSetUp : MonoBehaviour
{
    public GameObject[] levels;

    public TextAsset levelsInfo;

    public GameObject textAux;

    // Start is called before the first frame update
    void Start()
    {
        setLevelsInformationTA();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void setLevelsInformationTA()
    {

        //string[] lines = Regex.Split(levelsInfo.text, "\n|\r|\r\n");
        string[] lines = levelsInfo.text.Split('\n');


        int maxSongs = lines.Length;
        Debug.Log("Number of songs: " + maxSongs);


        for (int i = 0; i < maxSongs; i++)
        {
            string[] parts = lines[i].Split('|');

            Debug.Log("Primero: " + parts[0]);
            Debug.Log("Segundo: " + parts[1]);
            Debug.Log("Tercero: " + parts[2]);


            string[] levelScores = parts[2].Split(',');

            levels[i].GetComponent<LevelInformation>().setInformation(int.Parse(parts[0]), parts[1], int.Parse(levelScores[0]), int.Parse(levelScores[1]),
                int.Parse(levelScores[2]), int.Parse(levelScores[3]), int.Parse(levelScores[4]));
            


            
        }

        for (int i = maxSongs; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }

    }

    /*
    public void setLevelsInformation()
    {
        //Debug.Log(levelsInfo.name);

        Debug.Log("what? oh: " + aux.ToString());
        Debug.Log("Im trying this: " + Application.persistentDataPath);

        Debug.Log(Directory.GetCurrentDirectory() + @"\Assets\Resources\" + levelsInfo.name + ".txt");
        
        string path = Directory.GetCurrentDirectory() + @"Assets/Resources/" + levelsInfo.name + ".txt";

        textAux.GetComponent<Text>().text = path;

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            int i = 0;
            int maxSongs = 0;
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                if (i == 0)
                {
                    maxSongs = int.Parse(s);
                }
                else
                {
                    String[] parts = s.Split('|');

                    if (i <=  maxSongs)
                    {
                        levels[i-1].GetComponent<LevelInformation>().setInformation(int.Parse(parts[0]), parts[1], int.Parse(parts[2]));
                    }
                    

                    Debug.Log("Primero: " + parts[0]);
                    Debug.Log("Segundo: " + parts[1]);
                    Debug.Log("Tercero: " + parts[2]);
                    //Console.WriteLine(s);
                }

                i++;
            }
        }

        //for (int i = 0; i <)

        
    }*/
}
