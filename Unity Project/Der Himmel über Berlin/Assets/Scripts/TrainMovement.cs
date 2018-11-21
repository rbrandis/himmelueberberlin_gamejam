using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {

    public Transform[] Target;
    public float Speed;

    private int _current; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != Target[_current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, Target[_current].position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else _current = (_current + 1) % Target.Length;
    }
}
