using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    // Input actions
    public PlayerActions playerControls;
    public SpriteRenderer playerSprtRend;

    public SpriteRenderer weaponSprtRend;


    Material mat;

    // Public variabels to be set in inspector
    public Transform playerTransfom;
    public Transform rotateForWeapon;
    public Transform deflectWeapon;
    public Transform arm;
    public Collider2D weaponCollider;
    public float weaponDist = 1.0f;

    // Private variabels
    private Vector2 mousePos;
    private Vector3 playerScreenPos;
    private float angle;
    private List<Collider2D> deflectabels = new List<Collider2D>();

    private void Awake() {
        playerControls = new PlayerActions();
        playerControls.Controls.Deflect.performed += onDeflect;

    }

    private void FixedUpdate() {
        rotateWeapon();
        if( !Input.GetKey( KeyCode.Mouse0 ) ){
            weaponSprtRend.flipX = false;
        }else
        {
            weaponSprtRend.flipX = true;
        }
    }

    private void rotateWeapon() {
        mousePos = playerControls.Controls.MousePosition.ReadValue<Vector2>();
        playerScreenPos = Camera.main.WorldToScreenPoint(playerTransfom.position);

        Vector2 dir = new Vector2(mousePos.x - playerScreenPos.x, mousePos.y - playerScreenPos.y);
        dir = dir.normalized;
        
        rotateForWeapon.transform.localPosition = new Vector3(dir.x * weaponDist, dir.y * weaponDist, 0.0f);

        mousePos.x = mousePos.x - playerScreenPos.x;
        mousePos.y = mousePos.y - playerScreenPos.y;
        angle = Mathf.Atan2( mousePos.y, mousePos.x ) * Mathf.Rad2Deg;

        if(angle < -90 ||angle > 90 )
        {
            rotatePlayer(true);
        }
        else
        {
            rotatePlayer( false );
        }

        rotateForWeapon.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 scale = transform.localScale;
        if (Vector2.Dot(Vector2.right, dir) < 0.0f)
        {
            scale.y = -1;
        } else {
            scale.y = 1;
        }
        transform.localScale = scale;
    }

    public void rotatePlayer(bool flip)
    {
        playerSprtRend.flipX = flip;
    }

    public void onDeflect(InputAction.CallbackContext ctx) {

    }

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }
}
