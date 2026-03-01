using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //import
    public GameObject cameraUI;
    public GameObject invisEnemy;

    [Header("Stat")]
    [SerializeField] float moveSpeed;     
    [SerializeField] float hitRange;     
    [SerializeField] float hitDamage;
    [SerializeField] LayerMask layerMask;
    
    //Flag
    public bool isCameraOn;

    //inisialisasi
    public PlayerState playerState;

    void Awake()
    {
        isCameraOn =false;
        playerState= PlayerState.NORMAL;
        cameraUI.SetActive(false);
        invisEnemy.SetActive(false);
    }
    void Update()
    {

        //input
        Walk(); 
        if (Mouse.current.rightButton.wasPressedThisFrame && !isCameraOn)
        {
            playerState = PlayerState.CAMERA;
            Debug.Log("kamera");
        }else if (Mouse.current.rightButton.wasReleasedThisFrame && isCameraOn)
        {
            Debug.Log("normal");
            playerState = PlayerState.NORMAL;
        }


        switch (playerState)
        {
            case(PlayerState.NORMAL):
                isCameraOn=false;
                cameraUI.SetActive(false);
                invisEnemy.SetActive(false);//ganti jadi courutine
                break;
            case(PlayerState.CAMERA):
                cameraUI.SetActive(true);//ganti jadi courutine
                invisEnemy.SetActive(true);//ganti jadi courutine
                isCameraOn=true; 
                if (Input.GetMouseButtonDown(0))
                {
                    Capture();
                }
                break;
        }
    }
    void Walk()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Capture()
    {
        Debug.Log("capture");
        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out RaycastHit hitInfo, hitRange, layerMask))
        {
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hitInfo.distance,Color.blue,layerMask);
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Damage(hitDamage);
            }
        }
    }
}


public enum PlayerState
{
    NORMAL,
    CAMERA
}