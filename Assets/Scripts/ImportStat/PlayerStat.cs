using UnityEngine;

[System.Serializable]
public class PlayerStat : BaseStat 
{
    [Header("Player Stats")]
    public LayerMask layerMask;
    public float hitRange;
    public GameObject camera; 
    public int currentBattery;
    public int maxBattery;
}