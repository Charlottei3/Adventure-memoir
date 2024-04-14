using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAIPathfinding : MonoBehaviour
{
    public Transform target, enemyGFX;
    public float speed;
    public float nextWaypointDistance;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachEndofPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector2 _oldPosition;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        _oldPosition = rb.position;

        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    private void UpdatePath()
    {
        float _distanceCheckPlayer = Vector2.Distance(_oldPosition, target.position);
        if (_distanceCheckPlayer < 10)
        {
            if (seeker.IsDone())
                seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else
        {
            seeker.CancelCurrentPathRequest();
        }
    }
    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (path == null) return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachEndofPath = true;
            return;
        }
        else
        {
            reachEndofPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if (rb.velocity.x < 0)
        {
            enemyGFX.localScale = Vector2.one;
        }
        else
        {
            enemyGFX.localScale = new Vector2(-1, 1);
        }
    }
}
