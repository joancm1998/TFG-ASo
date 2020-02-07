using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float tX;
    float tY;
    Vector3 startPosition;
    Vector3 targetX;
    Vector3 targetY;
    float timeToReachTarget;

    public bool isActive;


    public GameObject destinationX;
    public GameObject destinationY;

    float extraY;

    void Start()
    {
        isActive = false;
        startPosition = targetX = transform.position;
        setDestination(destinationX.transform.position, destinationY.transform.position, GameManager.instance.song.clip.length);
        extraY = (targetY.y - targetX.y) / GameManager.instance.totalNotes;

    }

    void Update()
    {
        if(isActive)
        {
            characterMoveX();
        }
    }

    public void setDestination(Vector3 destinationX, Vector3 destinationY, float time)
    {
        tX = 0;
        tY = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        targetX = destinationX;
        targetY = destinationY;
    }

    public void characterMoveX()
    {
        tX += Time.deltaTime / timeToReachTarget;
        //startPosition += new Vector3(0f, 0.5f, 0f);
        //targetX += new Vector3(0f, 0.5f * Time.deltaTime, 0f);
        transform.position = Vector3.Lerp(startPosition, targetX, tX);
        Debug.Log("porision 1: " + transform.position);
        //transform.position += new Vector3(0f, 0.5f, 0f);
        Debug.Log("porision 2: " + transform.position);
    }

    public void characterMoveY(bool positive)
    {
        if (positive)
        {
            targetX += new Vector3(0f, extraY, 0f);
            Debug.Log("Uno mas");
        }
        else
        {
            targetX -= new Vector3(0f, extraY, 0f);
            Debug.Log("Uno menos");

            if(targetX.y < destinationX.transform.position.y)
            {
                targetX.y = destinationX.transform.position.y;
            }
        }
    }

}
