using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationPanel : MonoBehaviour
{
    public GameObject InformationPanelGM, InformationImageGM, InformationTextBacgGroundGM;
    public TextMeshProUGUI InformationTitleText, InformationExplantionText, InformationKeyText;

    public List<Image> ResourcesImages = new List<Image>();

    public void Information(string Title, string Explation,string imageName ,string key ,bool Active)
    {
        InformationTitleText.text = Title;
        InformationExplantionText.text = Explation;
        if(imageName != "null")
        {
            InformationImageGM.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(imageName);
            InformationImageGM.SetActive(true);
        }
        else //imageName == "null"
        {   
            InformationImageGM.SetActive(false); InformationImageGM.gameObject.GetComponent<Image>().sprite = null;    
            if(key != "")
            {
                InformationKeyText.text = key;
                InformationTextBacgGroundGM.SetActive(true);
            }
            else
            {
                InformationKeyText.text = "";
                InformationTextBacgGroundGM.SetActive(false);
            }
        }
        InformationPanelGM.SetActive(Active);
    }
}
