using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissedNote : MonoBehaviour
{
    private Collider2D collidingNote = null;

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
        if (other.tag == "Activator" && other.GetComponent<SpriteRenderer>().enabled == true)
        {
            this.collidingNote = other;
            this.failNote();
        }
    }

    public void failNote()
    {
        this.collidingNote.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.instance.failNote();
        GameManager.instance.didNote();
    }
}
