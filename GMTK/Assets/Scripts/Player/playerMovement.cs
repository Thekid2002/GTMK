using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    // Input actions
    public PlayerActions playerControls;

    // Public variabels to be set in inspector
    public Rigidbody2D playerRB;
    public Transform playerTransfom;
    public Transform weapon;
    public float weaponDist = 1.0f;
    public float moveSpeed = 5.0f;
    public float distToCam = 14.0f;

    public GameObject[] hearts;

    // Private variabels
    private Vector2 inputMovement;
    private Vector2 rawInputMovement;
    private Vector2 mousePos;
    private Vector3 playerScreenPos;
    private float angle;
    private float health = 3;
    public GameObject defeatPanel;


    private void Awake() {
        playerControls = new PlayerActions();
    }

    private void FixedUpdate() {
        rawInputMovement = playerControls.Controls.Movement.ReadValue<Vector2>();
        inputMovement = rawInputMovement * moveSpeed;

        playerRB.MovePosition(playerRB.position + inputMovement * Time.fixedDeltaTime);
    }

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }

    public void removeHealth()
    {
        health -= 1;
        switch( health )
        {
            case 2:
                hearts[2].SetActive( false );
                break;
            case 1:
                hearts[1].SetActive( false );
                break;
            case 0:
                hearts[0].SetActive( false );
                defeatPanel.SetActive( true );
                Destroy( gameObject );
                break;
        }
    }

}
