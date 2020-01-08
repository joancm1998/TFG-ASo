using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class LevelsSetUp : MonoBehaviour
{
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        setLevelsInformation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLevelsInformation()
    {
        Debug.Log(Directory.GetCurrentDirectory() + @"\Assets\GameInfo\LevelsInfo1.txt");
        
        string path = Directory.GetCurrentDirectory() + @"\Assets\GameInfo\LevelsInfo1.txt";

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

        
    }
}
