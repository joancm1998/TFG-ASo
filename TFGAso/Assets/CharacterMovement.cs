using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    public bool isActive;


    public GameObject destination;

    void Start()
    {
        isActive = false;
        startPosition = target = transform.position;
        setDestination(destination.transform.position, GameManager.instance.song.clip.length);
    }

    void Update()
    {
        if(isActive)
        {
            characterMove();
        }
    }

    public void setDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }

    public void characterMove()
    {
        t += Time.deltaTime / timeToReachTarget;
        //startPosition += new Vector3(0f, 0.5f, 0f);
        target += new Vector3(0f, 0.5f * Time.deltaTime, 0f);
        transform.position = Vector3.Lerp(startPosition, target, t);
        Debug.Log("porision 1: " + transform.position);
        //transform.position += new Vector3(0f, 0.5f, 0f);
        Debug.Log("porision 2: " + transform.position);
    }

}
