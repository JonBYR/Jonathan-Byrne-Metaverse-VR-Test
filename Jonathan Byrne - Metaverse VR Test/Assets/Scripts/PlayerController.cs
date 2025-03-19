using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    [SerializeField] float moveForce;
    private Vector2 moveDirection;
    [SerializeField] InputActionReference move; //New input system learnt from this tutorial https://www.youtube.com/watch?v=ONlMEZs9Rgw
    [SerializeField] float torqueSpeed;
    bool capsized = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
        if (transform.rotation.x >= 160 || transform.rotation.z >= 160) capsized = true; //should the boat have crashed for any reason and therefore be the wrong way up, disallow movement
        else capsized = false;
    }
    private void FixedUpdate()
    {
        if(!capsized)
        {
            if (moveDirection.x != 0)
            {
                playerRb.angularDrag = 0f;
                playerRb.AddTorque(transform.forward * moveDirection.x * torqueSpeed); //turning will be in the z axis
            }
            else
            {
                playerRb.angularDrag = 0.8f;
            }
            if (moveDirection.y != 0)
            {
                playerRb.drag = 0f;
                playerRb.AddForce(-transform.up * moveDirection.y * moveForce); //boat is rotated in the x direction, so movement will be in the y axis
            }
            else
            {
                playerRb.drag = moveForce / 10;
            }
        }
    }
}
