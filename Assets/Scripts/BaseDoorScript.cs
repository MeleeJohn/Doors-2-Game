using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class BaseDoorScript : MonoBehaviour
{
    public bool doorOpen;
    public int amountOfLocksOnDoor;
    public GameObject[] doorLocks;
    public Animator animator;
    
    public GameController GC;

    public GameObject roomObject;
    public Animator roomAnimator;
    public List<GameObject> ActiveLocksForDoor = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //numberOfLocks = doorLocks.Length;
        //StartCoroutine(SpawnLocks());
    }

    // Update is called once per frame
    void Update()
    {
        if(amountOfLocksOnDoor <= 0 && doorOpen != true) {
            doorOpen = true;
            Debug.Log("Welcome to hell bitch, enjoy your stay.");
            animator.SetBool("DoorOpen", true);
            StartCoroutine(GC.NextRoom(roomObject));
            StartCoroutine(NewDoor());
        }
    }

    public IEnumerator SpawnLocks() {
        amountOfLocksOnDoor = Random.Range(1, doorLocks.Length);
        Debug.Log("Number of Locks for this door is: " + amountOfLocksOnDoor);
        for (int i = 0; i < amountOfLocksOnDoor; i++) {
            Debug.Log("i @ Start of loop is: " + i);
            int LockToSpawn = Random.Range(0, doorLocks.Length);
            if(doorLocks[LockToSpawn].activeSelf == false) {
                doorLocks[LockToSpawn].SetActive(true);
                ActiveLocksForDoor.Add(doorLocks[LockToSpawn]);
            } else {
                i--;
            }
            Debug.Log("Looping");
            yield return new WaitForSeconds(0f);
        }
    }

    public void RefreshLocks() {
        if(ActiveLocksForDoor.Count > 0) {
            for (int i = 0; i < ActiveLocksForDoor.Count; i++) {
                ActiveLocksForDoor[i].SetActive(false);
            }
            ActiveLocksForDoor.Clear();
            amountOfLocksOnDoor = 0;
        }
    }

    public IEnumerator NewDoor () {
        yield return new WaitForSeconds(0.6f);
        roomAnimator.SetBool("OriginToEnd", false);
        roomAnimator.SetBool("SpawnToOrigin", false);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("CloseDoor",true);
        animator.SetBool("DoorOpen", false);
        yield return new WaitForSeconds(0.35f);
        animator.SetBool("CloseDoor", false);
        amountOfLocksOnDoor = 0;
        for (int i = 0; i < ActiveLocksForDoor.Count; i++) {
            ActiveLocksForDoor[i].SetActive(false);
        }
        ActiveLocksForDoor.Clear();
        //StartCoroutine(SpawnLocks());
        doorOpen = false;
        roomObject.GetComponent<BaseRoomScript>().NewDoor();
    }
}
