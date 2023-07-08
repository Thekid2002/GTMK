using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Public variabels to be set in inspector
    public Rigidbody2D projectileRB;
    public float projectileSpeed = 50.0f;

    // Private variabels
    private Transform origin;

    private void FixedUpdate() {
        if (Vector2.Distance(this.transform.position, origin.position) > 10){
            Destroy(this.gameObject);
        }
    }

    public void addForce(Vector2 direction, Transform _origin) {
        origin = _origin;
        projectileRB.AddForce(direction * projectileSpeed); 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "fireball" || other.collider.tag == "wall") {
            Destroy(this.gameObject);
        }
    }
}
