using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject referenceNote;

    public void Start()
    {

    }

    public void pressNote()
    {
        

        referenceNote.GetComponent<NoteObject>().pressNote();
    }
}
