using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void FixedUpdate() {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smootedPosition = Vector3.Lerp(player.position, desiredPosition, smoothSpeed);
        transform.position = smootedPosition;
    }
}
