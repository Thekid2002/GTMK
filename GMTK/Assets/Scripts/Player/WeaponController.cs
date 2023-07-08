using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public PlayerActions playerControls;

    public Transform playerTransfom;
    public Transform weapon;
    public float weaponDist = 1.0f;

    private Vector2 mousePos;
    private Vector3 playerScreenPos;
    private float angle;
    private void Awake() {
        playerControls = new PlayerActions();
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

    private void OnEnable() {
        playerControls.Controls.Enable();
    }

    private void OnDisable() {
        playerControls.Controls.Disable();
    }
}
