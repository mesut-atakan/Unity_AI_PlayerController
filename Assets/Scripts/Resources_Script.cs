using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resources_Script : MonoBehaviour
{

    public List<Sprite> images = new List<Sprite>();
    public GameObject ContactButton;
    private void Start() 
    {
        Sprite myData = Resources.Load<Sprite>("key");
        images.Add(myData);
    }

    public void SpriteImage(string name)
    {
        /*Sprite myData = Resources.Load<Sprite>(name);
        images.Add(myData);
        ContactButton.SetActive(true);*/

        /*Debug.Log("TEMAS!!");
        RamObject = other.gameObject;
        if(other.tag == "Key")
        {
            imageObject.SetActive(true);
            ContactButtonImage.sprite = res.images[0];
        }*/
    }
}
