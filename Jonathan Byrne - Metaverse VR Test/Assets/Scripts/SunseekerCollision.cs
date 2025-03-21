using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunseekerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true; //when kinematic changes in rotation through angularvelocity should be ignored
        Invoke("TurnOffKinematic", 0.2f); //still want the bobbing effect, so remove kinematic quickly
    }
    void TurnOffKinematic()
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    
}
