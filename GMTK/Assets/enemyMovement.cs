using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;

    float timer = 0;

    bool readyToShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if( timer > 5 && !readyToShoot )
        {
            SetDestination( player.transform.position + ( player.transform.position - transform.position ) * 0.2f + new Vector3( Random.Range( -3, 4 ), Random.Range( -3, 4 ) ));
            readyToShoot = true;
        }

        if(timer > 8 && readyToShoot )
        {
            Debug.Log( "SHOOT" );
            readyToShoot = false;
            timer = 0;
        }
    }

    void SetDestination( Vector3 vec )
    {
        var agentDrift = 0.0001f; // minimal
        var driftPos = vec + ( Vector3 )( agentDrift * Random.insideUnitCircle );
        agent.SetDestination( driftPos );
    }
}
