using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLockScript : MonoBehaviour
{
    public GameObject DoorScript;
    public Collider HandleLockCollider;
    // Start is called before the first frame update
    void Start()
    {
        //DoorScript = GameObject.FindGameObjectWithTag("Door");
        //DoorScript.GetComponent<Doors>().AddLock();
        HandleLockCollider = GetComponent<Collider>();
        //this.transform.parent = DoorScript.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (HandleLockCollider.Raycast(ray, out hit, 100.0f)) {
                Debug.Log("Hey you unlocked me, great job faggot I'm sure mommy and daddy looooove you");
                DoorScript.GetComponent<BaseDoorScript>().amountOfLocksOnDoor--;
            }
        }
    }
}
