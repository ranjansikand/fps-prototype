using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
	Rigidbody ball;
	private GameObject player;
	private Camera goPro;
	public Vector3 offset;
	public float force;

	private bool pickedUp = false;

	Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody>();
        player = GameObject.Find("FirstPerson");
        goPro = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
    	lookDirection = goPro.transform.position;
    	lookDirection = goPro.transform.forward * 50.0f;
    	if (pickedUp) {
    		transform.position = player.transform.position + offset;
    		ball.useGravity = false;
    		if (Input.GetKeyDown("space")) {
    			pickedUp = false;
    			ball.useGravity = true;
    			ball.AddForce(lookDirection * force * Time.deltaTime, ForceMode.Impulse);
    		}
    	} else {
    		ball.useGravity = true;
    	}
    }

    void OnMouseDown() {
    	if (pickedUp) {
    		pickedUp = false;
    	} else {
    		pickedUp = true;
    	}
    	
    }

    void OnTriggerEnter() {
    	Destroy(gameObject);
    }
}
