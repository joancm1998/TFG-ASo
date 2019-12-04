using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject note;

    public void pressNote()
    {

        note.GetComponent<NoteObject>().pressNote();
        
    }
}
