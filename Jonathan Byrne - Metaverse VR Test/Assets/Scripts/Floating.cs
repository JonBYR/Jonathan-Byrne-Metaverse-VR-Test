using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float depthBeforeSubmerged = 1f;
    [SerializeField] private float displacmentAmount = 3f; //https://www.youtube.com/watch?v=eL_zHQEju8s this tutorial used for bouyancy for enemy ship
    [SerializeField] private float depthLevel = 0;
    private void FixedUpdate() //this script was initially used for player, however did not have the desired effect, however works as desired for the enemy ships
    {
        if(transform.position.y < depthLevel) //if ship is below the water (it's y coordinate is less than the depth level)
        {
            float displacmentMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacmentAmount; //this statement approximates how much of the object is submerged
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y * displacmentMultiplier), 0f), ForceMode.Acceleration); //add upwards force to object based on how much is underwater
            //ForceMode.Acceleration used so that the bouyancy is not affected by mass
        }
    }
}
