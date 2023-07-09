using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : PuzzleObject
{
    public Sprite locked;
    public Sprite unlocked;

    private SpriteRenderer sprtRend;

    private void Start() {
        sprtRend = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() {
        changeSprite();
    }

    // Update is called once per frame
    private void changeSprite() {
        if( isActive ){
            if (sprtRend.sprite != unlocked) {
                sprtRend.sprite = unlocked;
                moveGate(1);
            }
        } else {
            if (sprtRend.sprite != locked) {
                sprtRend.sprite = locked;
                moveGate(-1);
            }
        }
    }

    private void moveGate(int multiplier) {
        transform.Translate(new Vector3(0, -3, 0) * multiplier);
    }
}
