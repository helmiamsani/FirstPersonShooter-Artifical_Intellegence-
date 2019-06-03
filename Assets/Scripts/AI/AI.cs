using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float maxVelocity = 15f, maxDistance = 10f;
    public Vector3 velocity;
    public SteeringBehaviour[] behaviours;
    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        
    }
}
