using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public int width = 1920;
    public int height = 1080;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(width, height, true);
        Debug.Log("Resultion set to width: " + width + " height: " + height);
        Debug.Log("Checking resolution, width: " + Screen.width + " height: " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
