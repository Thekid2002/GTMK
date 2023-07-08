using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreassurePlate : PuzzleObject
{
    public Sprite pressed;
    public Sprite unPressed;

    private SpriteRenderer sprtRend;

    private void Start() {
        sprtRend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "enemy") {
            isActive = true;
        }
    }

    private void changeSprite() {
        if( isActive ){
            sprtRend.sprite = pressed;
        } else {
            sprtRend.sprite = unPressed;
        }
    }
}
