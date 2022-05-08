using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlasLight_System : MonoBehaviour
{
    [Header("Flaslight")]
    public Light FlasLight;
    [HideInInspector] public float batteryEnergy;
    [Range(0f, 1f)] public float EnergyDuration;
    [HideInInspector] public static int batteryNumber;
    private static int MaxBattery;
    [HideInInspector]public bool FlaslightOn;

    [Header("Aniimations")]
    public Animator BatteryRedAnim;
    public TextMeshProUGUI BatteryChargeText;


    private void Start() 
    {
        batteryNumber = 3;
        batteryEnergy = 100f;
        //EnergyDuration = 0.85f;
        MaxBattery = 6;
        BatteryNumberUISystem();
    }

    private void Update() 
    {
        BatteryControl();
        FlasLightController();
        BatteryEnergyUI();
    }


    private void FlasLightController()
    {
        if(Input.GetKeyDown(KeyCode.F) && batteryEnergy > 0 && FlaslightOn == true)
        {
            FlasLight.enabled = !FlasLight.enabled;
            Debug.Log("Flaslight Button Sound Effect" + "\n" + "FlasLight Animation");
        }
    }
    
    

    public static void BatteryLoot()
    {
        if(batteryNumber < MaxBattery)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                batteryNumber++;
            }
        }
    }

    



    public List<GameObject> batteryNumberList = new List<GameObject>();

    public void BatteryControl()
    {
        if(batteryNumber > 0 || FlasLight.enabled == true && batteryEnergy > 0)
        {
            FlaslightOn = true;
            if(batteryEnergy > 0)
            {
                FlaslightOn = true;
                if(FlasLight.enabled == true)
                {
                    batteryEnergy -= Time.deltaTime * EnergyDuration;
                    BatteryChargeText.text = "%" + System.Convert.ToInt32(batteryEnergy).ToString();
                }
                //Debug.Log("Batary Energy: " + batteryEnergy.ToString());
            }
            else if(batteryEnergy <= 0)
            {
                FlaslightOn = false;
            }

            if(Input.GetKeyDown(KeyCode.Q) && batteryEnergy <= 100 && batteryNumber > 0)
            {
                FlasLight.enabled = false;
                batteryNumber--;
                batteryEnergy = 100f;
                FlaslightOn = true;
                BatteryChargeText.text = "%" + System.Convert.ToInt32(batteryEnergy).ToString();
                BatteryNumberUISystem();
                Debug.Log("Batery Restart Sound Effect");
            }
        }
        else if(batteryEnergy <= 0)
        {
            FlaslightOn = false;
            FlasLight.enabled = false;
        }

        if(batteryEnergy <= 0)
        {
            FlasLight.enabled = false;
            batteryEnergy = 0;
        }
    }

    public void BatteryNumberUISystem()
    {
        Debug.Log("BatteryNumber: " + batteryNumber);

        for(int a = 0; a <= 4; a++)
        {
            batteryNumberList[a].SetActive(false);
        }

        
        for(int i = 0; i <= batteryNumber - 1; i++)
        {
            batteryNumberList[i].SetActive(true);
        }
        
    }




    public List<GameObject> batteryUI = new List<GameObject>();
    public void BatteryEnergyUI()
    {
        if(batteryEnergy >= 80)
        {
            BatteryRedAnim.SetBool("Active", false);
            for(int i = 0; i <= batteryUI.Count - 1; i++)
            {
                batteryUI[i].SetActive(true);
            }
        }

        if(batteryEnergy <= batteryEnergy % 80)
        {
            BatteryRedAnim.SetBool("Active", false);
            for(int i = 1; i <= batteryUI.Count - 2; i++)
            {
                batteryUI[i].SetActive(true);
                batteryUI[batteryUI.Count - 1].SetActive(false);
            }
        }

        if(batteryEnergy <= batteryEnergy % 60)
        {
            BatteryRedAnim.SetBool("Active", false);
            for(int i = 0; i <= batteryUI.Count - 3; i++)
            {
                batteryUI[i].SetActive(true);
                batteryUI[batteryUI.Count - 1].SetActive(false);
                batteryUI[batteryUI.Count - 2].SetActive(false);
            }
        }

        if(batteryEnergy <= batteryEnergy % 40)
        {
            BatteryRedAnim.SetBool("Active", false);
            for(int i = 0; i <= batteryUI.Count - 4; i++)
            {
                batteryUI[i].SetActive(true);
                batteryUI[batteryUI.Count - 1].SetActive(false);
                batteryUI[batteryUI.Count - 2].SetActive(false);
                batteryUI[batteryUI.Count - 3].SetActive(false);
            }
        }

        if(batteryEnergy <= batteryEnergy % 20)
        {
            BatteryRedAnim.SetBool("Active", true);
            for(int i = 0; i <= batteryUI.Count - 5; i++)
            {
                batteryUI[i].SetActive(true);
                batteryUI[batteryUI.Count - 1].SetActive(false);
                batteryUI[batteryUI.Count - 2].SetActive(false);
                batteryUI[batteryUI.Count - 3].SetActive(false);
                batteryUI[batteryUI.Count - 4].SetActive(false);
            }
        }

        if(batteryEnergy <= 0)
        {
            BatteryRedAnim.SetBool("Active", false);
            for(int i = 0; i <= batteryUI.Count - 1; i++)
            {
                batteryUI[i].SetActive(false);
            }
        }
    }
}
