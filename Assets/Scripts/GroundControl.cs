using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    bool GroundContact;
     private void OnTriggerStay(Collider other)
    {
        if(other.tag != null) GroundContact = true;
        //Debug.Log("start");
        if(GroundContact == true)
        {
            if(other.tag == "wood")
            {
                Debug.Log("wood Sound Effect");
            }

            if(other.tag == "stone")
            {
                Debug.Log("stone Sound Effect");
            }

            if(other.tag == "soil")
            {
                Debug.Log("soil Sound Effect");
            }
        }
    }
}
