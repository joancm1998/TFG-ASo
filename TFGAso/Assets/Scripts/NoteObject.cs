using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;

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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            this.canBePressed = false;
        }
    }

    public void pressNote()
    {
        if (this.canBePressed)
        {
            this.correctNote();
        }
    }

    public void correctNote()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.correctNote();
    }
}
