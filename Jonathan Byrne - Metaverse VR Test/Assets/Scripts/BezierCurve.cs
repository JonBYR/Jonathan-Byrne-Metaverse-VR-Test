using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private float time;
    private bool endReached = false;
    [SerializeField] private float timeScale;
    [SerializeField] private List<GameObject> checkpoints = new List<GameObject>();
    [SerializeField] private float totalRotation = 0;
    [SerializeField] private float degreePerSecond = 10f;
    [SerializeField] private float rotationAmount = 180f;
    float priorY;
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
        if(time >= 1f && endReached != true)
        {
            endReached = true;
            time = 0;
        }
        if(endReached == true)
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
        if(endReached == false)
        {
            Vector3 newPosition = GetBezier(checkpoints, time);
            transform.LookAt(newPosition, -Vector3.up); //ship needs to be turning towards the position on the bezier curve, so use lookAt
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }
    }
    void RotateShip()
    {
        float currentY = transform.localRotation.eulerAngles.y;
        transform.localRotation = Quaternion.Euler(-90, currentY + (Time.deltaTime * degreePerSecond), 0); //rotate boat so that it flips it's direction before traversing back along the path
        totalRotation += Time.deltaTime * degreePerSecond;
    }
}
