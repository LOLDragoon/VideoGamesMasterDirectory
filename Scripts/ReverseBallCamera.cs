using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReverseBallCamera : MonoBehaviour {

	private Camera playerCam;
	private GameObject player;


	// Use this for initialization
	void Start () 
	{
		playerCam	= Camera.main;
		player = GameObject.FindGameObjectWithTag ("Ball");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Ball")) 
		{
			playerCam.GetComponent<CamController> ().HalfwaySwitch();
		}
		
	}



}
