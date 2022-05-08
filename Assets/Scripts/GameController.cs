using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Room Variables
    public GameObject roomBase;
    public GameObject CurrentRoom;
    public GameObject OldRoom;

    //room position variables
    public GameObject RoomSpawnPoint;
    public GameObject RoomMoveEndPoint;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if (hit.transform.gameObject != null)
            {
                if (hit.transform.gameObject.CompareTag("Lock") == true)
                {
                    hit.transform.gameObject.GetComponent<BaseLockScript>().UnLock();
                    //Debug.Log("Found a lock");
                }
                else
                {
                    Debug.Log("That ain't a lock");
                }
            }
        }
    }

    public void ChangeRooms()
    {
        CurrentRoom.transform.GetComponent<Animator>().SetBool("RoomMayMove",true);
        StartCoroutine(DoorUnlockedAnimationEnd());
        OldRoom = CurrentRoom;
        CurrentRoom = Object.Instantiate(roomBase, RoomSpawnPoint.transform.position, RoomSpawnPoint.transform.rotation);
    }


    public IEnumerator DoorUnlockedAnimationEnd()
    {
        yield return new WaitForSeconds(2.5f);
        //gameController.ChangeRooms();
        Destroy(OldRoom);
    }
}
