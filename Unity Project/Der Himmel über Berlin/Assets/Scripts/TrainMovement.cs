using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour {

    public Transform[] Target;
    public float Speed;
    public float RotationSpeed;

    private int _current; 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        /*if (transform.position != Target[_current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, Target[_current].position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else _current = (_current + 1) % Target.Length;*/



        //Rotation
        Vector3 relativePos = Target[_current].position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Quaternion rotationOverTime = Quaternion.RotateTowards(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
        print(rotationOverTime);
        transform.rotation = rotationOverTime;


        if (Vector3.Distance(transform.position, Target[_current].position) > 0.01f)
        {


            //Movement
            Vector3 pos = Vector3.MoveTowards(transform.position, Target[_current].position, Speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else _current = (_current + 1) % Target.Length;
    }
}
