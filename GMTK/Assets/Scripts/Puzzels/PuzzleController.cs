using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public bool needsKey = false;
    public bool gotKey = false;
    public PuzzleObject key;
    public PuzzleObject lockedDoor;
    public GameObject door;
    public List<PuzzleObject> puzzleObjectives = new List<PuzzleObject>();

    private int completion = 0;
    private int maxObjectives;
    // Start is called before the first frame update
    void Start() {
        maxObjectives = puzzleObjectives.Count;
    }

    // Update is called once per frame
    void Update() {
        completion = 0;
        foreach (PuzzleObject item in  puzzleObjectives) {
            if (item.isActive) {
                completion++;
            }
        }

        if (key.isActive) {
            lockedDoor.isActive = true;
        }

        if (completion == maxObjectives) {
            door.GetComponent<DoorController>().doorOpened = true;
        } else {
            door.GetComponent<DoorController>().doorOpened = false;
        }
    }
}
