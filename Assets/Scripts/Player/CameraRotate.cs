using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] float sensitivityX;
    [SerializeField] float sensitivityY;
     float xRotation =0f;
     float yRotation =0f;
    [SerializeField] Transform cameraTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*sensitivityX*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*sensitivityY*Time.deltaTime;

        yRotation +=mouseX;
        xRotation -=mouseY;

        xRotation = math.clamp(xRotation,-90f,90f);

        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);
        cameraTransform.rotation = Quaternion.Euler(0,yRotation,0);
        //transform.localRotation = quaternion.Euler(xRotation,0f,0f);
        //cameraTransform.Rotate(Vector3.up*mouseX);
    }
}
