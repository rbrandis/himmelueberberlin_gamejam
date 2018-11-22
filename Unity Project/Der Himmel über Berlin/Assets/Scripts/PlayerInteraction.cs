using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public LayerMask Mask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        InteractRaycast();
	}

    void InteractRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if(Physics.Raycast(ray, out hit, 5.0f, Mask))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
        else
        {
            Debug.Log("-");
        }
    }
}
