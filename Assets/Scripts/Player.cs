using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Stat")]
    [SerializeField] float moveSpeed;     
    [SerializeField] float hitRange;     
    [SerializeField] float hitDamage;
    [SerializeField] LayerMask layerMask;
    

    //inisialisasi
    public PlayerState playerState;
    void Awake() //subcribe
    {
        GameManager.onGameStateChange += onGameStateChange;
    }
    void OnDestroy() //unsubcribe
    {
        GameManager.onGameStateChange -= onGameStateChange;        
    }

    //kalau dipanggil event nya langsung nyala
    void onGameStateChange(GameState gameState)
    {

    }

    void Update()
    {


        Walk();
        if (Input.GetMouseButtonDown(0))
        {
            Capture();
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