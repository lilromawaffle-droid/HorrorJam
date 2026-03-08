using UnityEngine;
using UnityEngine.UI;

public class HealrthbarUi : MonoBehaviour
{
    public static HealrthbarUi instance;
    void Awake()
    {
        instance =this;        
    }
    [SerializeField] private Slider sliderSanity;
    public void MaxSanity(float maxSanity)
    {
        sliderSanity.maxValue = maxSanity;
    }
    public void CurrentSanity(float valueSanity)
    {
        sliderSanity.value = valueSanity;
    }
}
