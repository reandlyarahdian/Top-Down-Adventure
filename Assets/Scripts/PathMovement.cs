using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public PathEditor path;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    public float health;

    void Start()
    {
        path = FindObjectOfType<PathEditor>();
        lastWaypointSwitchTime = Time.time;
    }

    void Update()
    {

        Vector3 startPosition = path.transforms[currentWaypoint].transform.position;
        Vector3 endPosition = path.transforms[currentWaypoint + 1].transform.position;

        float pathLength = Vector2.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
 
        if (transform.position.Equals(endPosition))
        {
            if (currentWaypoint < path.transforms.Count - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;

            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    /*public PathEditor pathEditor;
    public float moveSpeed;
    public float moveRotation;
    public int currentWayPointID = 0;

    Vector2 lastPos;

    void Start()
    {
        lastPos = transform.position;
    }

    void Update()
    {
        float distance = Vector2.Distance(pathEditor.transforms[currentWayPointID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, pathEditor.transforms[currentWayPointID].position, moveSpeed * Time.deltaTime);

        
        if(transform.position == pathEditor.transforms[currentWayPointID].position)
        {
            currentWayPointID++;
        }

    }*/
}
