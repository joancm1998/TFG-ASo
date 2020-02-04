using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using System.IO;

public class LevelsSetUp : MonoBehaviour
{
    public GameObject[] levels;

    public TextAsset levelsInfo;

    public GameObject groupTitle;

    // Start is called before the first frame update
    void Start()
    {
        //setLevelsInformationAndroid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    public void setLevelsInformationTA()
    {

        //string[] lines = Regex.Split(levelsInfo.text, "\n|\r|\r\n");
        string[] lines = levelsInfo.text.Split('\n');
        //string filePath = Application.streamingAssetsPath + "/LevelsInfo1.txt";
        //StreamReader file = new StreamReader(filePath);
        

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
        
        Debug.Log("Changing the content of the file...");

        string aux = lines[0];
        aux = string.Concat(aux, '\n');
        for(int i = 1; i < lines.Length; i++)
        {
            aux = string.Concat(aux, lines[i]);
            aux = string.Concat(aux, '\n');
        }
        aux = string.Concat(aux, "10|TINC UN ZOO 3|0,0,0,0,0");
        string filePath = Application.streamingAssetsPath + "/LevelsInfo1.txt";
        Debug.Log("File in: " + filePath);
        File.WriteAllText(filePath, aux);
        //File.WriteAllText(AssetDatabase.GetAssetPath(levelsInfo), aux);
        //File.WriteAllText(AssetDatabase.GetAssetPath(levelsInfo), "TRY1");

        EditorUtility.SetDirty(levelsInfo);

        Debug.Log("Content Changed!");

    }
    */
    
    public void setLevelsInformation()
    {
        //Debug.Log(levelsInfo.name);

        /*Debug.Log("what? oh: " + aux.ToString());
        Debug.Log("Im trying this: " + Application.persistentDataPath);

        Debug.Log(Directory.GetCurrentDirectory() + @"\Assets\Resources\" + levelsInfo.name + ".txt");*/
        string path = Application.streamingAssetsPath + "/LevelsInfo1.txt";
        //string path = Directory.GetCurrentDirectory() + @"Assets/Resources/" + levelsInfo.name + ".txt";

        //textAux.GetComponent<Text>().text = path;

        // Open the file to read from.
        using (StreamReader sr = File.OpenText(path))
        {
            int i = 0;
            int maxSongs = 0;
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                
                    string[] parts = s.Split('|');
                    string[] levelScores = parts[2].Split(',');

                   
                    levels[i].GetComponent<LevelInformation>().setInformation(int.Parse(parts[0]), parts[1], int.Parse(levelScores[0]), int.Parse(levelScores[1]),
               int.Parse(levelScores[2]), int.Parse(levelScores[3]), int.Parse(levelScores[4]));
                    
                    

                    Debug.Log("Primero: " + parts[0]);
                    Debug.Log("Segundo: " + parts[1]);
                    Debug.Log("Tercero: " + parts[2]);
                    //Console.WriteLine(s);
                

                i++;
            }

            for (int j = i; j < levels.Length; j++)
            {
                levels[j].SetActive(false);
            }
        }

        //for (int i = 0; i <)

        
    }

    public void setLevelsInformationAndroid(string group)
    {
        //TextAsset textAsset = Resources.Load("LevelsInfo1") as TextAsset;
        TextAsset textAsset = Resources.Load<TextAsset>(group);
        groupTitle.GetComponent<Text>().text = group;
        /*string info = r.ReadToEnd();
        r.Close();*/

        Debug.Log(textAsset.text);
        string[] lines = textAsset.text.Split('\n');

        int maxSongs = lines.Length;
        Debug.Log("Number of songs: " + maxSongs);


        for (int i = 0; i < maxSongs; i++)
        {
            string[] parts = lines[i].Split('|');

            Debug.Log("Primero: " + parts[0]);
            Debug.Log("Segundo: " + parts[1]);
            Debug.Log("Tercero: " + parts[2]);


            string[] levelScores = parts[2].Split(',');

            for (int j = 0; j < levelScores.Length; j++)
            {
                //Debug.Log("Saving data from: " + parts[1] + j);
                LoadSaveManager.instance.saveLevelScore(parts[1], j+1, int.Parse(levelScores[j]));
            }

            levels[i].GetComponent<LevelInformation>().setInformation(int.Parse(parts[0]), parts[1], int.Parse(levelScores[0]), int.Parse(levelScores[1]),
                int.Parse(levelScores[2]), int.Parse(levelScores[3]), int.Parse(levelScores[4]));

            
            



        }

        for (int i = maxSongs; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }

        Debug.Log("Changing the content of the file...");

        string aux = lines[0];
        aux = string.Concat(aux, '\n');
        for (int i = 1; i < lines.Length; i++)
        {
            aux = string.Concat(aux, lines[i]);
            aux = string.Concat(aux, '\n');
        }
        aux = string.Concat(aux, "10|TINC UN ZOO 3|0,0,0,0,0");
        //string filePath = Application.streamingAssetsPath + "/LevelsInfo1.txt";
        //Debug.Log("File in: " + filePath);
        //File.WriteAllText(filePath, aux);
        //File.WriteAllText(AssetDatabase.GetAssetPath(levelsInfo), aux);
        //File.WriteAllText(AssetDatabase.GetAssetPath(levelsInfo), "TRY1");

        //EditorUtility.SetDirty(levelsInfo);

        Debug.Log("Content Changed!");
    }


}
