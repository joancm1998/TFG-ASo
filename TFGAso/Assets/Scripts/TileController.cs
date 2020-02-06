using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject referenceNote;
    public AudioSource keySound;
    public bool hasSound = false;

    public void Start()
    {

    }

    public void pressNote()
    {
        if (hasSound)
            keySound.Play();

        referenceNote.GetComponent<NoteObject>().pressNote();
    }
}
