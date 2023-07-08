using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    // Input actions
    public PlayerActions playerControls;

    // Public variabels to be set in inspector
    public Transform playerTransfom;
    public Transform weapon;
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
    }

    private void rotateWeapon() {
        mousePos = playerControls.Controls.MousePosition.ReadValue<Vector2>();
        playerScreenPos = Camera.main.WorldToScreenPoint(playerTransfom.position);

        Vector2 dir = new Vector2(mousePos.x - playerScreenPos.x, mousePos.y - playerScreenPos.y);
        dir = dir.normalized;
        
        weapon.transform.localPosition = new Vector3(dir.x * weaponDist, dir.y * weaponDist, 0.0f);

        mousePos.x = mousePos.x - playerScreenPos.x;
        mousePos.y = mousePos.y - playerScreenPos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        weapon.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 scale = transform.localScale;
        if (Vector2.Dot(Vector2.right, dir) < 0.0f)
        {
            scale.y = -1;
        } else {
            scale.y = 1;
        }
        transform.localScale = scale;
    }

    public void onDeflect(InputAction.CallbackContext ctx) {
        if (deflectabels.Count > 0) {
            foreach (Collider2D item in deflectabels) {
                Rigidbody2D itemRB = item.GetComponent<Rigidbody2D>();
                Vector2 lastVelocity = itemRB.velocity;
                float velocity = itemRB.velocity.magnitude;
                
                Vector2 dir = new Vector2(weapon.position.x - playerTransfom.position.x, weapon.position.y - playerTransfom.position.y);
                Vector2 direction = Vector2.Reflect(lastVelocity.normalized, dir.normalized);
                
                itemRB.velocity = direction * velocity;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!deflectabels.Contains(other)) {
            deflectabels.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (deflectabels.Contains(other)) {
            deflectabels.Remove(other);
        }
    }

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }
}
