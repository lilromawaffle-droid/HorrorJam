using UnityEngine;

public class Greed : MonoBehaviour
{
    void Start()
    {
        
    }
    void OnDestroy()
    {
        PlayerStateMachine.instance.PlusBattery(2);
    }

}
