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
    private CharacterController characterController;

    //event
    public event Action onCameraActivate;
    public event Action onCameraDeactivate;
    public event Action onPlayerDie;
    public event Action <int> onBatteryInteractPlus;
    public event Action <int> onBatteryInteractMin;


    void Awake()
    {
        instance = this;
        isCameraOn =false;
        playerState= PlayerState.NORMAL;
          characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Debug.DrawRay(
        // playerStat.camera.transform.position,
        // playerStat.camera.transform.TransformDirection(Vector3.forward) * playerStat.hitRange,
        // Color.red);
        Debug.DrawRay(
        playerStat.camera.transform.position,
        playerStat.camera.transform.forward * playerStat.hitRange,
        Color.yellow);

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
            Capture();        
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

        // Ambil arah kamera, tapi flatten (ignore sumbu Y)
        Vector3 camForward = playerStat.camera.transform.forward;
        Vector3 camRight = playerStat.camera.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        // Gerak mengikuti arah kamera
        Vector3 movement = (camForward * verticalInput + camRight * horizontalInput);

        characterController.Move(movement * playerStat.moveSpeed * Time.deltaTime);
    }
    
    void Walked()
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
        RaycastHit hitInfo;
        
        Debug.Log("capture");
        if (Physics.Raycast(playerStat.camera.transform.position,playerStat.camera.transform.TransformDirection(Vector3.forward),out  hitInfo, playerStat.hitRange,playerStat.layerMask))
        {
            Debug.Log("hit something");
            Debug.DrawRay(playerStat.camera.transform.position,playerStat.camera.transform.TransformDirection(Vector3.forward)*hitInfo.distance,Color.blue,playerStat.layerMask);
            EnemyEventHandler enemy = hitInfo.transform.GetComponent<EnemyEventHandler>();
            if (enemy != null)
            {
                enemy.TakeDamage(playerStat.hitDamage);
                Debug.DrawRay(
                playerStat.camera.transform.position,
                playerStat.camera.transform.forward * hitInfo.distance,
                Color.green,
                0.5f);
            }
        }
        else
        {
            Debug.Log("hit nithun");
            Debug.DrawRay(
            playerStat.camera.transform.position,
            playerStat.camera.transform.forward * playerStat.hitRange,
            Color.red,
            0.5f);
        }
        MinBattery(1);
    } 


    void MinBattery(int cost)
    {
        playerStat.currentBattery -= cost;
        onBatteryInteractMin?.Invoke(cost);
    }

    void PlusBattery(int cost)
    {
        playerStat.currentBattery += cost;
        onBatteryInteractPlus?.Invoke(cost);
        
    }
#endregion
}


public enum PlayerState
{
    NORMAL,
    CAMERA
}