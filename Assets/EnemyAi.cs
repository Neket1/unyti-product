using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using static UnityEngine.GraphicsBuffer;
using static Cinemachine.CinemachineTargetGroup;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public Transform enemyGXF;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;

    int cucurrentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;//он управляеет пере
    Rigidbody2D rb;
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            cucurrentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;
        if (cucurrentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[cucurrentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[cucurrentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            cucurrentWaypoint++;
        }
        if (rb.velocity.x >= 0.01f)
        {
            enemyGXF.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x <= 0.01f)
        {
            enemyGXF.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
