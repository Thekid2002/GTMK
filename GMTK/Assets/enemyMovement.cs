using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{
    // Public variabels to be set in inspector
    public GameObject projectile;


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
            fire();
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

    private void fire()
    {
        GameObject instance = Instantiate( projectile, transform.position, Quaternion.identity );
        instance.GetComponent<ProjectileBehaviour>().addForce( new Vector2( (instance.transform.position.x-player.transform.position.x)*-1, (instance.transform.position.y-player.transform.position.y)*-1 ), transform );
    }
}
