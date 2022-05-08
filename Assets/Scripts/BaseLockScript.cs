using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLockScript : MonoBehaviour
{
    public GameObject DoorParent;
    private BaseDoorScript DoorParentScript;
    private Collider HandleLockCollider;

    bool locked = true;

    void Start()
    {

        DoorParent = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        DoorParentScript = DoorParent.GetComponent<BaseDoorScript>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UnLock()
    {
        if (locked == true)
        {
            locked = false;
            DoorParentScript.locksUnlocked++;
            Debug.Log("Hey you unlocked me");
        }
    }
}
