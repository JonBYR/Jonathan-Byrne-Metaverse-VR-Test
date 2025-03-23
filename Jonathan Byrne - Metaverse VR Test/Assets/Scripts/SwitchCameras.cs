using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class SwitchCameras : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera mainCamera;
    [SerializeField] CinemachineVirtualCamera backCamera;
    public void ChangePriorities(bool forward) //call this function when w or s is pressed
    {
        if (forward)
        {
            mainCamera.Priority = 20; //if w is pressed then camera needs to show what is in pront of the player
            backCamera.Priority = 5;
        }
        else
        {
            mainCamera.Priority = 5; //if s is pressed camera needs to show what is behind the player
            backCamera.Priority = 20;
        }
    }
}
