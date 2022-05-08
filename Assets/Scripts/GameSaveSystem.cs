using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaveSystem : MonoBehaviour
{
    public List<Light> Lamps = new List<Light>();

    public Transform PlayerTransform;
    FlasLight_System FL;
    public GameObject FLOB;

    private void Awake() 
    {
        FL = FLOB.gameObject.GetComponent<FlasLight_System>();
    }

    private void Start() 
    {
        LampLoadSystem();
        PlayerTransformLoad();
        BatteryLoad();
    }

    public void LampLoadSystem()
    {
        for(int i = 0; i <= Lamps.Count; i++)
        {
            if(PlayerPrefs.HasKey("Lamp_" + i))
            {
                Lamps[i].enabled = Convert.ToBoolean(PlayerPrefs.GetString("Lamp_" + i.ToString()));
            }
        }
    }

    public void PlayerTransformLoad()
    {
        if(PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            Debug.Log("Transform Update");
            PlayerTransform.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"), PlayerPrefs.GetFloat("PlayerY"), PlayerPrefs.GetFloat("PlayerZ"));
        }
        
    }

    public void BatteryLoad()
    {
        if(PlayerPrefs.HasKey("BatteryNumber"))
        {
            FlasLight_System.batteryNumber = PlayerPrefs.GetInt("BatteryNumber");
        }
        
        if(PlayerPrefs.HasKey("BatteryEnergy"))
        {
            FL.batteryEnergy = PlayerPrefs.GetFloat("BatteryEnergy");
        }
    }


    //SAVE SYSTEM /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void Update() 
    {
        SaveSystem();
    }


    public void SaveSystem()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Save");
            LampSaveSystem();
            PlayerTransformSave();
            BatterySave();
        }
    }

    public void LampSaveSystem()
    {
        for(int i = 0; i <= Lamps.Count - 1; i++)
        {
            PlayerPrefs.SetString("Lamp_" + i, Lamps[i].enabled.ToString()); //lamp_i - "True" or "false"
        }
    }

    public void PlayerTransformSave()
    {
        PlayerPrefs.SetFloat("PlayerX", PlayerTransform.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", PlayerTransform.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", PlayerTransform.transform.position.z);
    }

    public void BatterySave()
    {
        PlayerPrefs.SetFloat("BatteryEnergy", FL.batteryEnergy);
        PlayerPrefs.SetInt("BatteryNumber", FlasLight_System.batteryNumber);
    }
}
