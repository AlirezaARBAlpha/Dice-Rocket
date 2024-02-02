using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	static Rigidbody rb;
	public static Vector3 diceVelocity;
	public Transform transform;
    Vector3 lastPos;
    Vector3 newPos;
	public Vector3 initPosition;
    float t;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
		rb.isKinematic = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = rb.velocity;

		if (Input.GetKeyDown (KeyCode.Space)) {
			//DiceNumberTextScript.diceNumber = 0;
			float dirX = Random.Range (0, 500);
			float dirY = Random.Range (0, 500);
			float dirZ = Random.Range (0, 500);
			//transform.rotation = new Vector3 (dirX, dirY, dirZ);
			Debug.Log(dirX);
			Debug.Log(dirY);
			Debug.Log(dirZ);
		}
	}

	public void StartRollDice () {
		lastPos = transform.eulerAngles;
		initPosition = transform.position;
        //NewAngle();
		transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
		rb.AddForce (transform.up * 50f);
		rb.isKinematic = false;
	}

    public void NewAngle()
    {
        lastPos = newPos;
        newPos = new Vector3(
                     Random.Range(-10f, 10f),
                     Random.Range(0f, 360f),
                     Random.Range(-10f, 10f));
    }

	public void Reset()
    {
        transform.position = initPosition;
		rb.isKinematic = true;
    }
}
