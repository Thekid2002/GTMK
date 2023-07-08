using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetDestination( new Vector3( 18, 0, -2 ) );
    }

    void SetDestination( Vector3 vec )
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = vec + ( Vector3 )( agentDrift * Random.insideUnitCircle );
        agent.SetDestination( driftPos );
    }
}
