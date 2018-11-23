using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public LayerMask Mask;

    public DialogueController Controller;

    private float _timer;

    private DialogueTarget _target;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Controller.IsPlaying) return;
        InteractRaycast();
	}

    void InteractRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit; 

        if(Physics.Raycast(ray, out hit, 2.0f, Mask))
        {
            //Debug.Log(hit.transform.gameObject.name);

            _timer += Time.deltaTime;

            if(_timer >= 1.0f)
            {
                _timer = 0;

                var currentTarget = hit.collider.GetComponent<DialogueTarget>();
                if (currentTarget != null && currentTarget != _target)
                {
                    _target = currentTarget;
                    Controller.StartDialogue(_target.DialogueStartingPoint.GetObject());
                }
            }
        }
        else
        {
            //Debug.Log("-");

            _timer = 0;

            _target = null;

        }
    }
}
