using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float moveForce;
    private Vector2 moveDirection;
    [SerializeField] InputActionReference move; //New input system learnt from this tutorial https://www.youtube.com/watch?v=ONlMEZs9Rgw
    [SerializeField] float torqueSpeed;
    bool capsized = false;
    [SerializeField] private float timer = 3.0f;
    bool showUI = false;
    [SerializeField] GameObject winPanel;
    [SerializeField] float dragWhileMoving;
    private SwitchCameras cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<SwitchCameras>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>(); //get movement input
        if (ObjectiveZoneReached.triggerEntered == true && moveDirection.x == 0 && moveDirection.y == 0 && showUI == false) //check that trigger is entered and that there is no movement in the x and y axis
        {
            if (Mathf.Abs(transform.rotation.eulerAngles.y) >= 120 && Mathf.Abs(transform.rotation.eulerAngles.y) <= 240) //ship must be docked portside, so y angle must fall between these two angles
            {
                timer -= Time.deltaTime; //if conditions are met, deincrement time
                if (timer <= 0) showUI = true;
            }
        }
        else timer = 3.0f;
        if (Mathf.Abs(transform.rotation.eulerAngles.x) >= 90 && Mathf.Abs(transform.rotation.eulerAngles.x) <= 270) capsized = true;
        else if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 90 && Mathf.Abs(transform.rotation.eulerAngles.z) <= 270) capsized = true; //should the boat have crashed for any reason and therefore be the wrong way up, disallow movement
        else capsized = false;
        if (showUI) DisplayWinUI(); //once the timer condition is met display the UI
    }
    private void FixedUpdate()
    {
        Debug.Log("This is the velocity: " + playerRb.velocity.magnitude);
        if(!capsized)
        {
            //if (moveDirection.y > 0) cam.ChangePriorities(true);
            //else if (moveDirection.y < 0) cam.ChangePriorities(false);
            if (moveDirection.x != 0 && moveDirection.y != 0)
            { //only turn should there also be forward momentum 
                playerRb.angularDrag = 0f;
                playerRb.AddTorque(transform.up * moveDirection.x * torqueSpeed); //turning will be in the y axis
            }
            else
            {
                playerRb.angularDrag = 0.8f;
            }
            if (moveDirection.y != 0)
            {
                playerRb.drag = dragWhileMoving;
                playerRb.AddForce(transform.forward * moveDirection.y * moveForce); //move forwards based on directional input, acceleration applied naturally
            }
            else
            {
                playerRb.drag = moveForce / 10;
            }
        }
    }
    void DisplayWinUI()
    {
        winPanel.SetActive(true);
    }
}
