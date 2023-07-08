using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public Rigidbody2D projectileRB;
    public float projectileSpeed = 50.0f;

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
}
