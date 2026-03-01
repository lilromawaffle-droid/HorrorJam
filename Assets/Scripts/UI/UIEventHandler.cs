using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    void Start()
    {    
        PlayerStateMachine.instance.onCameraActivate += OnCameraActivate;        
        PlayerStateMachine.instance.onCameraDeactivate += OnCameraDeactivate;        
        this.gameObject.SetActive(false);
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
