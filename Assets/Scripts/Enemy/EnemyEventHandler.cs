using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    [SerializeField]EnemyStat enemyStat;
    void Start()
    {    
        PlayerStateMachine.instance.onCameraActivate += OnCameraActivate;        
        PlayerStateMachine.instance.onCameraDeactivate += OnCameraDeactivate;
    }
    private void OnDestroy()
    {
        PlayerStateMachine.instance.onCameraDeactivate -= OnCameraDeactivate;        
        PlayerStateMachine.instance.onCameraActivate -= OnCameraActivate;
        GameManager.instance.enemyDeathCounter ++;
    }

    void OnCameraActivate()
    {
        enemyStat.manifestObject.SetActive(true);
        enemyStat.symbolObject.SetActive(false);
        Debug.Log("Manifest On");
        //gameObject.SetActive(true);
    }

    void OnCameraDeactivate()
    {
        enemyStat.manifestObject.SetActive(false);
        enemyStat.symbolObject.SetActive(true);
        Debug.Log("Symbol On");
        //gameObject.SetActive(false);        
    }
    public void Damage(float damage)
    {
        enemyStat.Hp -= damage;
        if (enemyStat.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
