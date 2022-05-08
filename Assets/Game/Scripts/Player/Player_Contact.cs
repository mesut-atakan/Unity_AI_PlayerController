using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Contact : MonoBehaviour
{
    public Image ContactButtonImage;
    public GameObject imageObject;
    public GameObject ResourcesScript;
    Resources_Script res;

    List<string> envanter = new List<string>();
    GameObject RamObject;

    private void Start() 
    {
        res = ResourcesScript.gameObject.GetComponent<Resources_Script>();
        ContactButtonImage.enabled = true;
        ContactButtonImage.sprite = null;
        imageObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("TEMAS!!");
        RamObject = other.gameObject;
        if(other.tag == "Key")
        {
            imageObject.SetActive(true);
            ContactButtonImage.sprite = res.images[0];
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        RamObject = null;
        imageObject.SetActive(false);
    }


    public void PlayerContact_Button()
    {
        Debug.Log(RamObject.gameObject.name + " Objesi Silindi!");
        Destroy(RamObject);
        ContactButtonImage.sprite = null;
        imageObject.SetActive(false);
    }
}
