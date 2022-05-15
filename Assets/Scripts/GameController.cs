using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    //Room Variables
    public GameObject roomBase;
    public GameObject CurrentRoom;
    public GameObject OldRoom;

    //room position variables
    public GameObject RoomSpawnPoint;
    public GameObject RoomMoveEndPoint;

    //Scoring
    public int Score;
    public TextMeshProUGUI scoreText;

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

        scoreText.text = Score.ToString();
    }

    public void ChangeRooms()
    {
        //CurrentRoom.transform.GetComponent<Animator>().SetBool("RoomMayMove",true);
        //StartCoroutine(DoorUnlockedAnimationEnd());
        Object.Instantiate(roomBase, RoomSpawnPoint.transform.position, RoomSpawnPoint.transform.rotation);
    }


    public IEnumerator DoorUnlockedAnimationEnd()
    {
        yield return new WaitForSeconds(0f);
        //OldRoom = CurrentRoom;
        CurrentRoom = Object.Instantiate(roomBase, RoomSpawnPoint.transform.position, RoomSpawnPoint.transform.rotation);
        //yield return new WaitForSeconds(1.5f);
        //gameController.ChangeRooms();
        //Destroy(OldRoom);
    }
}
