    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{

    public float tempo;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
        }
        //transform.position -= new Vector3(tempo * Time.deltaTime, 0f, 0f);
        //transform.position -= new Vector3(tempo, 0f, 0f);
        //Debug.Log(Time.deltaTime);
    }
}
