using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] float time;
    bool endReached = false;
    [SerializeField] float timeScale;
    [SerializeField] List<GameObject> checkpoints = new List<GameObject>();
    [SerializeField] float totalRotation = 0;
    [SerializeField] float degreePerSecond = 10f;
    [SerializeField] float rotationAmount = 180f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    Vector3 GetBezier(List<GameObject> points, float t)
    {
        Vector3 resultingPos = BezierEquation.GetPointOnCurve(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position, t);
        BezierEquation.DrawLines(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position, t);
        return resultingPos;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
            time += Time.deltaTime * timeScale;
            if (time >= 1f)
            {
                endReached = true;
                time = 0;
            }
            if (endReached == true)
            {
                if (Mathf.Abs(totalRotation) < Mathf.Abs(rotationAmount))
                {
                    RotateShip();
                }
                else
                {
                    endReached = false;
                    time = 0;
                    totalRotation = 0;
                    checkpoints.Reverse();

                }
            }
            else if (endReached == false)
            {
                Vector3 newPosition = GetBezier(checkpoints, time);
                transform.LookAt(newPosition, -Vector3.up); //ship needs to be turning towards the position on the bezier curve, so use lookAt
                transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
            }
        
    }
    void RotateShip()
    {
        transform.RotateAround(transform.position, new Vector3(0, 1, 0), Time.fixedDeltaTime * degreePerSecond);
        totalRotation += Time.fixedDeltaTime * degreePerSecond;
        Debug.Log("Current Rotation:" + transform.rotation);
    }
}
