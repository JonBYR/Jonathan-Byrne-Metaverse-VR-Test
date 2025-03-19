using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacmentAmount = 3f; //https://www.youtube.com/watch?v=eL_zHQEju8s this tutorial used for bouyancy
    private void FixedUpdate()
    {
        if(transform.position.y < 1)
        {
            float displacmentMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacmentAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y * displacmentMultiplier), 0f), ForceMode.Acceleration);
        }
    }
}
