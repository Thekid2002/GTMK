using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Public variabels to be set in inspector
    public Transform firePos;
    public GameObject projectile;
    public float fireTime = 2f;
    
    // Private variabels
    private Vector3 fireDir;

    private void Start() {
        fireDir = firePos.position - transform.position;
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        fire();

        yield return new WaitForSeconds(fireTime);
        StartCoroutine(waiter());
    }

    private void fire() {
        GameObject instance = Instantiate(projectile, firePos.position, Quaternion.identity);
        instance.GetComponent<ProjectileBehaviour>().addForce(new Vector2(fireDir.x, fireDir.y), firePos);
    }
}
