using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField] private float time;
    private bool endReached = false;
    [SerializeField] private float timeScale;
    [SerializeField] private List<GameObject> checkpoints = new List<GameObject>();
    private Vector3 sunseekerPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveShip());
    }
    IEnumerator MoveShip()
    {
        time += Time.deltaTime * timeScale;
        if (time >= 1) time = 0;
        yield return new WaitForSeconds(1f);
    }
    Vector3 GetBezier(List<GameObject> points, float t)
    {
        Vector3 resultingPos = BezierEquation.GetPointOnCurve(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position, t);
        BezierEquation.DrawLines(points[0].transform.position, points[1].transform.position, points[2].transform.position, points[3].transform.position, t);
        return resultingPos;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * timeScale;
        if(time >= 1f)
        {
            time = 0;
            checkpoints.Reverse();
        }
        Vector3 newPosition = GetBezier(checkpoints, time);
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
    }
}
