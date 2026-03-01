using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    void Start()
    {    
        PlayerStateMachine.instance.onCameraActivate += OnCameraActivate;        
        PlayerStateMachine.instance.onCameraDeactivate += OnCameraDeactivate;        
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        PlayerStateMachine.instance.onCameraDeactivate -= OnCameraDeactivate;        
        PlayerStateMachine.instance.onCameraActivate -= OnCameraActivate;
    }

    void OnCameraActivate()
    {
        gameObject.SetActive(true);
    }

    void OnCameraDeactivate()
    {
        gameObject.SetActive(false);        
    }

}
