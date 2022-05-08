using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LazerSystem : MonoBehaviour
{
    public float LazerDistance;
    public GameObject ResourcesGameObject, ContactImage;
    Resources_Script reso;
    private bool doorOpen;

    public GameObject InformationPanelGameObject;
    InformationPanel Info;

    private void Start() 
    {
        reso = ResourcesGameObject.gameObject.GetComponent<Resources_Script>();
        Info = InformationPanelGameObject.gameObject.GetComponent<InformationPanel>();
        Debug.Log("Enabled: " + Info.enabled.ToString());
    }

    private void Update() 
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * LazerDistance, Color.red);
        if(Physics.Raycast(ray, out hit, LazerDistance))
        {
            Debug.Log("Collider name: " + hit.collider.tag);
            if(hit.collider.tag == "cheast")
            {
                Info.Information("Cheast", "Press the 'E' key to open or close the chest.", "null", "E", true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Cheast Anim,"+"\n"+
                        "cheast sound"+"\n"+
                        "cheast Inventory");
                }
            }

            if(hit.collider.tag == "door")
            {
                if(!doorOpen)
                {
                    Info.Information("Door Interaction", "You can interact with the 'E' key to open or close the door.", "null", "E", true);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Open the Door" + "\n" + "Sound Effect");
                        doorOpen = true;
                    }
                }
                else
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Debug.Log("Close the Door" + "\n" + "Sound Effect");
                        doorOpen = false;
                    }
                }
            }

            if(hit.collider.tag == "lightkey")
            {
                Debug.Log("Light Contact");
                Info.Information("bulb Active","You can turn the bulb on and off by pressing the 'E' key.", "null","E",true);//null değişecek!
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Light sound, light anim");
                    hit.collider.gameObject.GetComponentInChildren<Light>().enabled = !hit.collider.gameObject.GetComponentInChildren<Light>().enabled;
                }
            }

            if(hit.collider.tag == "Untagged")
            {
                Info.Information("", "", "null", "", false);
            }
        }
        else
        {
            Info.Information("", "", "null", "", false);
            ContactImage.SetActive(false); ContactImage.GetComponentInChildren<Image>().sprite = null;
        }
    }
}
