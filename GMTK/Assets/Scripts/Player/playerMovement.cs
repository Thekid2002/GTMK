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
    public float distToCam = 14.0f;

    private Vector2 inputMovement;
    private Vector2 rawInputMovement;
    private Vector2 mousePos;
    private Vector3 playerScreenPos;
    private float angle;
    
    private void Awake() {
        playerControls = new PlayerActions();
    }

    private void FixedUpdate() {
        rawInputMovement = playerControls.Controls.Movement.ReadValue<Vector2>();
        inputMovement = rawInputMovement * moveSpeed;

        playerRB.MovePosition(playerRB.position + inputMovement * Time.fixedDeltaTime);

        mousePos = playerControls.Controls.MousePosition.ReadValue<Vector2>();
        playerScreenPos = Camera.main.WorldToScreenPoint(playerTransfom.position);
        
        mousePos.x = mousePos.x - playerScreenPos.x;
        mousePos.y = mousePos.y - playerScreenPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        playerTransfom.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }
}
