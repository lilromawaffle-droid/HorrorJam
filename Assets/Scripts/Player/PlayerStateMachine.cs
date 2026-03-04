using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : MonoBehaviour
{


    //import
    
    [SerializeField] PlayerStat playerStat;

    //Flag
    public bool isCameraOn;

    //inisialisasi
    public static PlayerStateMachine instance;
    public PlayerState playerState;
    private PlayerState previousState;
    public int currentBattery;

    //event
    public event Action onCameraActivate;
    public event Action onCameraDeactivate;
    public event Action onPlayerDie;
    public event Action <int> onBatteryInteractPlus;
    public event Action <int> onBatteryInteractMin;


    void Awake()
    {
        currentBattery = playerStat.currentBattery;
        instance = this;
        isCameraOn =false;
        playerState= PlayerState.NORMAL;
    }
    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
        DeathChecker();
        Walk();
        HandleInput();

        //  Event hanya invoke saat state berubah
        if (playerState != previousState)
        {
            OnStateChanged(playerState);
            previousState = playerState;
        }

        HandleCurrentState();
    }

#region input
    void HandleInput()
    {
        if (InpurManager.instance.onClickRightMouse() && !isCameraOn)
        {
            playerState = PlayerState.CAMERA;
        }
        else if (InpurManager.instance.onRealeasedRightMouse() && isCameraOn)
        {
            playerState = PlayerState.NORMAL;
        }
        if (InpurManager.instance.onClickLeftMouse() && isCameraOn)
        {
            if (currentBattery > 0)
            {
                Capture();
            }
        }

    }
#endregion 


#region playerState

//dipanggil pas pindah
    void OnStateChanged(PlayerState newState)
    {
        switch (newState)
        {
            case PlayerState.NORMAL:
                isCameraOn = false;
                onCameraDeactivate?.Invoke(); 
                playerStat.moveSpeed = playerStat.maxMoveSpeed;
                break;
            case PlayerState.CAMERA:
                onCameraActivate?.Invoke();
                isCameraOn = true;
                playerStat.moveSpeed -= playerStat.maxMoveSpeed/playerStat.moveSpeedDivider;
                break;
        }
    }

//dipanggil tiap frame
    void HandleCurrentState()
    {
        switch (playerState)
        {
            case PlayerState.NORMAL:
                break;
            case PlayerState.CAMERA:                
                break;
        }
    }
#endregion

#region function
    void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement *  playerStat.moveSpeed* Time.deltaTime);
    }

    void DeathChecker()
    {
        if (playerStat.currentBattery<=0)
        {
            onPlayerDie?.Invoke();
        }
    }

    void Capture()
    {
        Debug.Log("capture");
        if (Physics.Raycast(playerStat.camera.transform.position,playerStat.camera.transform.TransformDirection(Vector3.forward),out RaycastHit hitInfo, playerStat.hitRange, playerStat.layerMask))
        {
            Debug.DrawRay(playerStat.camera.transform.position,playerStat.camera.transform.TransformDirection(Vector3.forward)*hitInfo.distance,Color.blue,playerStat.layerMask);
            EnemyEventHandler enemy = hitInfo.transform.GetComponent<EnemyEventHandler>();
            if (enemy != null)
            {
                enemy.Damage(playerStat.hitDamage);
            }
        }
        MinBattery(1);
    }

    void MinBattery(int cost)
    {
        currentBattery -= cost;
        onBatteryInteractMin?.Invoke(cost);
    }

    void PlusBattery(int cost)
    {
        currentBattery += cost;
        onBatteryInteractPlus?.Invoke(cost);
        
    }
#endregion
}


public enum PlayerState
{
    NORMAL,
    CAMERA
}