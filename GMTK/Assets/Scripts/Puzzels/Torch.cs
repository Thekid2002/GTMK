using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : PuzzleObject
{
    public Sprite litTorchSprite;
    public Sprite torchSprite;
    private SpriteRenderer sprtRend;

    void Start()
    {
        sprtRend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (isActive) {
            changeSprite();
        } else {
            changeSprite();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "fireball") {
            isActive = true;
            changeSprite();
        }
    }

    private void changeSprite() {
        if( isActive ){
            sprtRend.sprite = litTorchSprite;
        } else {
            sprtRend.sprite = torchSprite;
        }
    }
}
