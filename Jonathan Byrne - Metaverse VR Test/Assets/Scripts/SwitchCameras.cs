using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class SwitchCameras : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineVirtualCamera backCamera;
    //[SerializeField] InputActionReference cameraButton;
    //private CinemachineVirtualCamera currentCamera;
    //Initial code to change from forward to backwards camera was done via a button press, however it was felt that the camera reversing when the player reversed was more natural.
    //Initial code is kept in just for testing purposes
    /*
    void Start()
    {
        currentCamera = mainCamera;
    }

    private void OnEnable()
    {
        cameraButton.action.started += ChangeCamera;
    }
    private void OnDisable()
    {
        cameraButton.action.started -= ChangeCamera;
    }
    void ChangeCamera(InputAction.CallbackContext context)
    {
        if (mainCamera == currentCamera) currentCamera = backCamera;
        else currentCamera = mainCamera;
        ChangePriorities(currentCamera);
    }
    void ChangePriorities(CinemachineVirtualCamera cam)
    {
        if (mainCamera == currentCamera)
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
    */
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
