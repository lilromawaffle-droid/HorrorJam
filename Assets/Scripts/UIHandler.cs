using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public List<GameObject> batteryBarActive = new List<GameObject>();

    int currentBattery ;
    
    void Start()
    {
        currentBattery =5;
        PlayerStateMachine.instance.onBatteryInteractPlus += BatteryInteractPlus; 
        PlayerStateMachine.instance.onBatteryInteractMin += BatteryInteractMin; 
    }

    void OnDestroy()
    {
        PlayerStateMachine.instance.onBatteryInteractPlus -= BatteryInteractPlus; 
        PlayerStateMachine.instance.onBatteryInteractMin -= BatteryInteractMin; 
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<batteryBarActive.Count;i++)
        {
            if (i<currentBattery)
            {   
                batteryBarActive[i].SetActive(true);
            }
            else
            {
                batteryBarActive[i].SetActive(false);
            }
        }
    }

    void BatteryInteractPlus(int importValue)
    {
        currentBattery += importValue;
    }
    void BatteryInteractMin(int importValue)
    {
        currentBattery -= importValue;
    }

}
