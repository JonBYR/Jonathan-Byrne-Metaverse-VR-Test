using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float moveForce;
    private Vector2 moveDirection;
    public InputActionReference move; //New input system learnt from this tutorial https://www.youtube.com/watch?v=ONlMEZs9Rgw
    public float torqueSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (moveDirection.x != 0)
        {
            playerRb.angularDrag = 0f;
            playerRb.AddTorque(transform.up * moveDirection.x * torqueSpeed);
        }
        else
        {
            playerRb.angularDrag = 0.8f;
        }
        if(moveDirection.y != 0)
        {
            playerRb.drag = 0f;
            playerRb.AddForce(transform.forward * moveDirection.y * moveForce);
        }
        else
        {
            playerRb.drag = moveForce / 10;
        }
    }
}
