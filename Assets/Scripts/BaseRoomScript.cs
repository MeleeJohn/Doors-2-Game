using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRoomScript : MonoBehaviour
{

    public GameObject[] differentDoors;
    public GameObject chosenDoor;
    public GameObject doorForRoom;
    public BaseDoorScript doorForRoomScript;

    void Start() {
        //alright here we go
        chosenDoor = differentDoors[Random.Range(1, differentDoors.Length)];
        chosenDoor.SetActive(true);
        StartCoroutine(chosenDoor.GetComponent<BaseDoorScript>().SpawnLocks());
    }

    public void NewDoor() {
        chosenDoor.SetActive(false);
        chosenDoor = null;
        chosenDoor = differentDoors[Random.Range(1, differentDoors.Length)];
        chosenDoor.SetActive(true);
        chosenDoor.GetComponent<BaseDoorScript>().RefreshLocks();
        StartCoroutine(chosenDoor.GetComponent<BaseDoorScript>().SpawnLocks());
    }

}
