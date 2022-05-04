using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject roomOne;
    public BaseRoomScript roomOneScript;
    public GameObject roomTwo;
    public BaseRoomScript roomTwoScript;

    // Start is called before the first frame update
    void Start()
    {
        roomOneScript = roomOne.GetComponent<BaseRoomScript>();
        roomTwoScript = roomTwo.GetComponent<BaseRoomScript>();
        roomOne.GetComponent<Animator>().SetBool("SpawnToOrigin", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator NextRoom(GameObject FinishedRoom) {
        yield return new WaitForSeconds(0.45f);
        if(FinishedRoom.name == roomOne.name) {
            yield return new WaitForSeconds(0.6f);
            roomOne.GetComponent<Animator>().SetBool("OriginToEnd", true);
            roomTwo.GetComponent<Animator>().SetBool("SpawnToOrigin", true);
            StartCoroutine(roomOneScript.doorForRoomScript.NewDoor());
        } else if(FinishedRoom.name == roomTwo.name) {
            yield return new WaitForSeconds(0.6f);
            roomTwo.GetComponent<Animator>().SetBool("OriginToEnd", true);
            roomOne.GetComponent<Animator>().SetBool("SpawnToOrigin", true);
            StartCoroutine(roomTwoScript.doorForRoomScript.NewDoor());
        }
    }
}
