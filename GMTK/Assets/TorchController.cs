using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    public bool torchLit;
    private bool checkLit = false;
    public Sprite litTorchSprite;
    public Sprite torchSprite;
    private SpriteRenderer sprtRend;

    // Start is called before the first frame update
    void Start()
    {
        sprtRend = gameObject.GetComponent<SpriteRenderer>();
        checkLit = torchLit;
    }

    // Update is called once per frame
    void Update()
    {
        if( torchLit != checkLit )
        {
            ChangeTorchState();
            checkLit = torchLit;
        }
    }


    public void ChangeTorchState()
    {
        if( torchLit )
        {
            sprtRend.sprite = litTorchSprite;
        }
        else
        {
            sprtRend.sprite = torchSprite;
        }
    }
}
