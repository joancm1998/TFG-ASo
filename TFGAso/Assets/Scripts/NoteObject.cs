using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public bool hasBeenPressed;
    private Collider2D collidingNote = null;

    //character
    public GameObject character;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            this.canBePressed = true;
            this.collidingNote = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            if(!this.hasBeenPressed)
            {
                this.missedNote();
            }

            this.canBePressed = false;
            this.collidingNote = null;
            this.hasBeenPressed = false;
        }
    }

    public void pressNote()
    {
        if (this.canBePressed && !this.hasBeenPressed)
        {
            this.correctNote();
        }
        else
        {
            if(!this.canBePressed)
            {
                this.failNote();
            }
        }
    }

    public void correctNote()
    {
        this.hasBeenPressed = true;
        this.collidingNote.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.correctNote();
        GameManager.instance.didNote();

        //Debug.Log(new Vector3(0f, this.transform.position.y, 0f));
        character.transform.position = new Vector3(character.transform.position.x, this.transform.position.y, character.transform.position.z);
        //character.transform.Translate(new Vector3(0f, this.transform.position.y, 0f));
    }

    public void failNote()
    {
        GameManager.instance.failNote();
    }

    public void missedNote()
    {
        this.collidingNote.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.failNote();
        GameManager.instance.didNote();
    }
}
