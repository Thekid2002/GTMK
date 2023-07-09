using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class PuzzleController : MonoBehaviour
{
    public bool needsKey = false;
    public bool gotKey = false;
    public PuzzleObject key;
    public PuzzleObject lockedDoor;
    public GameObject door;
    public List<TorchController> torches = new List<TorchController>();
    public List<GameObject> wizards = new List<GameObject>();

    public GameObject victoryPanel;
    public GameObject defeatPanel;

    // Update is called once per frame
    void Update() {
        foreach (TorchController torch in  torches) {
            if (torch.torchLit) {
                torches.Remove( torch );
            }
        }

        if (key.isActive) {
            lockedDoor.isActive = true;
        }

        foreach( GameObject wizard in wizards )
        {
            if( wizard.activeSelf == false )
            {
                wizards.Remove( wizard );
            }
        }
        if(torches.Count != 0 && wizards.Count == 0 )
        {
            Debug.Log( "Lost the game bro" );
            defeatPanel.SetActive(true);
        }
        if (torches.Count == wizards.Count && wizards.Count == 0) {
            door.GetComponent<DoorController>().doorOpened = true;
            victoryPanel.SetActive( true );
        }
        else {
            door.GetComponent<DoorController>().doorOpened = false;
        }
    }
}
