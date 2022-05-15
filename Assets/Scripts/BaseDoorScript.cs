using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class BaseDoorScript : MonoBehaviour
{
    public GameController gameController;
    public GameObject MiddleDoorPosition;
    private bool doorUnlocked = false;

    public GameObject[] possibleLocksForDoor;
    private int amountofLocksForDoor;
    public int locksUnlocked;

    private Animator doorAnimator;
    public BaseRoomScript topParentObjectScript;
    public GameObject topParentObject;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        doorAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        amountofLocksForDoor = Random.Range(1,10);
        SpawnLocks();
        //SetVariables();
    }

    private void SpawnLocks()
    {
        for(int i = 0; i < amountofLocksForDoor; i++)
        {
            int lockChoice = Random.Range(1, possibleLocksForDoor.Length);
            GameObject TempLock = Object.Instantiate(possibleLocksForDoor[lockChoice], new Vector3(0f, 0f, 0f), possibleLocksForDoor[lockChoice].transform.rotation,transform.GetChild(0));
            TempLock.transform.localPosition = new Vector3(MiddleDoorPosition.transform.localPosition.x, MiddleDoorPosition.transform.localPosition.y + Random.Range(-0.5f,0.5f), MiddleDoorPosition.transform.localPosition.z);
            TempLock = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(locksUnlocked == amountofLocksForDoor && doorUnlocked == false)
        {
            doorUnlocked = true;
            StartCoroutine(unlockDoor());
            Debug.Log("Woah I'm open");
        }
    }

    private IEnumerator unlockDoor()
    {
        gameController.Score++;
        topParentObject.GetComponent<Animator>().SetBool("RoomMayMove", true);
        Debug.Log("Moving Room");
        //gameController.ChangeRooms();
        yield return new WaitForSeconds(1f);
        Debug.Log("Changing Room and opening door");
        gameController.ChangeRooms();
        doorAnimator.SetBool("DoorOpen", true);
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Destroying Room");
        Destroy(topParentObject);
    }

    public void SetVariables()
    {
        gameController.CurrentRoom = topParentObject;
    }

    public void newLockLocation(GameObject lockToMove)
    {
        lockToMove.transform.localPosition = new Vector3(0f, MiddleDoorPosition.transform.localPosition.y + Random.Range(-0.25f, 0.5f), MiddleDoorPosition.transform.localPosition.z);
    }
}
