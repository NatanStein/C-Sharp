﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IAScript : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public Transform enemyGFX;
    public float nextWaypoint = 3f;
    Path path;
    int currentwaypoint = 0;
    bool reacheEndPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }
    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentwaypoint = 0;
        }
    }
    void FixedUpdate()
    {
        if (path == null)
            return;
        if(currentwaypoint >= path.vectorPath.Count)
        {
            reacheEndPath = true;
            return;
        }
        else
        {
            reacheEndPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentwaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentwaypoint]);

        if (distance < nextWaypoint)
        {
            currentwaypoint++;
        }
        if(force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
