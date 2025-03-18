using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float moveSpeed;
    private Vector2 moveDirection;
    public InputActionReference move; //New input system learnt from this tutorial https://www.youtube.com/watch?v=ONlMEZs9Rgw
    private Transform position;
    private float rotationinY;
    private float acceleration = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        position = this.gameObject.GetComponent<Transform>();
        rotationinY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        playerRb.velocity = new Vector3(moveDirection.x * moveSpeed, 0, moveDirection.y * moveSpeed);
        if (moveDirection.x != 0)
        {
            if (moveDirection.x < 0) rotationinY = -0.1f;
            else if (moveDirection.x > 0) rotationinY = 0.1f;
            transform.Rotate(new Vector3(0, rotationinY, 0), Space.Self);
        }
        else
        {
            rotationinY = 0;
            transform.Rotate(new Vector3(0, rotationinY, 0), Space.Self);
        }
    }
}
