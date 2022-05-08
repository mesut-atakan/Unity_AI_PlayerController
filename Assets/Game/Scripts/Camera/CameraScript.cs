using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Character;
    private Vector3 Distance;
    public float cameraMoveSpeed;

    public float Zoom, MaxZoom, MinZoom;

    void Start() 
    {
        Distance = transform.position - Character.transform.position; //we found the distance between the camera and the character
    }

    void LateUpdate() //this function runs after all update functions are finished
    {
        transform.position = Vector3.Lerp(transform.position, Character.transform.position + Distance, cameraMoveSpeed * Time.deltaTime);
    }

    private void CameraZoom()
    {
        Zoom = 0; MaxZoom = 20f; MinZoom = -5f;

        
    }
}

/*
        if (scroll != 0) 
        {
            float contentHeight = scrollRect.content.sizeDelta.y;
            float contentShift = speed * scroll * Time.deltaTime;
            scrollRect.verticalNormalizedPosition += contentShift / contentHeight;
        }
*/