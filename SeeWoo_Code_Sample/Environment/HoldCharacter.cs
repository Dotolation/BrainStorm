using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class makes sure that the player object moves with the platform
 * when it is on the moving platform
 */
public class HoldCharacter : MonoBehaviour {

    private void OnTriggerEnter(Collider col) // when the player is on the platform
    {
        if (col.tag == "Player")
        {
            col.transform.parent = transform; 
            //this puts player object a child of the platform object
            //...which guarentees that player will move along with the moving platform. 
        }
    }	
	// Update is called once per frame
	private void OnTriggerExit(Collider col) // when the player is no longer on the platform...
    {
        if (col.tag == "Player")
        {
            col.transform.parent = null; // no longer the parent of a moving object
        }
    }

}
