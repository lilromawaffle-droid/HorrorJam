using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private BillBoardType billBoardType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (billBoardType)
        {
            case BillBoardType.lookAtCamera:
                transform.LookAt(Camera.main.transform.position,Vector3.up);
                break;

            case BillBoardType.cameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
        }        
    }
}

public enum BillBoardType{
    lookAtCamera,
    cameraForward
    
}
