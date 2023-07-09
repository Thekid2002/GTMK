using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PuzzleObject
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "Player") {
            isActive = true;
            this.gameObject.SetActive(false);
        }
    }
}
