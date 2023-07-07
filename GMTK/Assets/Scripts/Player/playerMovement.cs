using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public PlayerActions playerControls;

    public Rigidbody2D playerRB;
    public Transform playerTransfom;
    public float moveSpeed = 5.0f;

    private Vector2 inputMovement;
    private Vector2 rawInputMovement;
    private Vector2 mousePos;
    private Vector2 mouseWorldPos;
    
    private void Awake() {
        playerControls = new PlayerActions();
    }

    private void FixedUpdate() {
        rawInputMovement = playerControls.Controls.Movement.ReadValue<Vector2>();
        inputMovement = rawInputMovement * moveSpeed;

        playerRB.MovePosition(playerRB.position + inputMovement * Time.fixedDeltaTime);

        mousePos = playerControls.Controls.MousePosition.ReadValue<Vector2>();
        mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Quaternion rotation = Quaternion.LookRotation(new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0) - transform.position, transform.TransformDirection(Vector3.up));
        playerTransfom.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }
}
