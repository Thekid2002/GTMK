using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Public variabels to be set in inspector
    public Rigidbody2D projectileRB;
    float projectileSpeed = 50;
    bool hitSword = false;


    // Private variabels
    float timer;


    private void FixedUpdate() {
        timer += Time.deltaTime;
        if (timer > 10){
            Destroy(this.gameObject);
        }
    }

    public void addForce(Vector2 direction, Transform _origin) {
        projectileRB.AddForce(direction * projectileSpeed); 
    }

    void OnCollisionEnter2D( Collision2D col )
    {
        Debug.Log( col.collider.gameObject.transform.tag );
        switch( col.collider.gameObject.transform.tag )
        {
            case "Defelctable":
                hitSword = true;
                break;
            case "Torch":
                col.gameObject.GetComponent<TorchController>().torchLit = true;
                Destroy( this.gameObject );
                break;
            case "Player":
                Debug.Log( "Ouch" );
                break;
            default:
                Destroy( this.gameObject );
                break;
        }
    }

    private void OnTriggerEnter2D( Collider2D col )
    {
        Debug.Log( col.gameObject.tag );
        if(hitSword && col.gameObject.tag == "Wizard" )
        {
            col.gameObject.SetActive( false );
            Destroy( this.gameObject );
        }
    }
}
