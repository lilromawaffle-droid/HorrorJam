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

    void Update()
    {
        
    }
    private void OnDestroy()
    {
        PlayerStateMachine.instance.onCameraDeactivate -= OnCameraDeactivate;        
        PlayerStateMachine.instance.onCameraActivate -= OnCameraActivate;
        GameManager.instance.enemyDeathCounter ++;
    }

    void OnCameraActivate()
    {
        if (enemyStat.manifestObject != null)
        {
            enemyStat.manifestObject.SetActive(true);
            
        }
        if (enemyStat.symbolObject != null)
        {
            enemyStat.symbolObject.SetActive(false);
        }

        Debug.Log("Manifest On");
        //gameObject.SetActive(true);
    }

    void OnCameraDeactivate()
    {
        if (enemyStat.manifestObject != null)
        {
            enemyStat.manifestObject.SetActive(false);
        }

        if (enemyStat.symbolObject != null)
        {
            enemyStat.symbolObject.SetActive(true);
        }
        Debug.Log("Symbol On");
        //gameObject.SetActive(false);        
    }
    public void TakeDamage(float damage)
    {
        enemyStat.Hp -= damage;
        Debug.Log("nerima "+damage+" damage");
        if (enemyStat.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
