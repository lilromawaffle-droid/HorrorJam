using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] Transform cameraPos;


    void Update()
    {
        transform.position = cameraPos.position;
    }
}
