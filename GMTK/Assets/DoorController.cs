using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool doorOpened;
    private bool checkOpened = false;
    public Sprite openedDoorSprite;
    public Sprite closedDoorSprite;
    private SpriteRenderer sprtRend;
    private BoxCollider2D boxCollid;

    // Start is called before the first frame update
    void Start()
    {
        sprtRend = gameObject.GetComponent<SpriteRenderer>();
        boxCollid = gameObject.GetComponent<BoxCollider2D>();
        checkOpened = doorOpened;
    }

    // Update is called once per frame
    void Update()
    {
       if(doorOpened != checkOpened )
        {
            ChangeDoorState();
            checkOpened = doorOpened;
        }
    }


    public void ChangeDoorState()
    {
        if( doorOpened )
        {
            sprtRend.sprite = openedDoorSprite;
            boxCollid.enabled = false;
        }
        else
        {
            sprtRend.sprite = closedDoorSprite;
            boxCollid.enabled = true;
        }
    }
}
