using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : MonoBehaviour
{
    
}
/*Vector3 direction = player.position - transform.position;
float angle = Vector3.Angle(direction, transform.forward);
return angle < 45f;



/*
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
 
        if (ground.Raycast(cameraRay, out rayLength))
        {
            Vector3 groundPoint = cameraRay.GetPoint(rayLength);
            transform.position = new Vector3(groundPoint.x, transform.position.y, groundPoint.z);
        }
*/