using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class SwitchCameras : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineVirtualCamera backCamera;
    // Start is called before the first frame update
    void Start()
    {
     
    }
    public void ChangePriorities(bool forward)
    {
        if (forward)
        {
            mainCamera.Priority = 20;
            backCamera.Priority = 5;
        }
        else
        {
            mainCamera.Priority = 5;
            backCamera.Priority = 20;
        }
    }
}
