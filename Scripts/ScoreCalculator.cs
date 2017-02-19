using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour {

	GameController gameController;
	public GameObject middle;
	public Camera playerCam;
	public GameObject player;
	public GameObject flag;
	public float score;
	public bool scoring;
	public Text scoreValue;


	// Use this for initialization
	void Start () 
	{
		playerCam = Camera.main;
		player = GameObject.FindGameObjectWithTag ("Ball");

		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
//		while (playerCam.GetComponent<CamController> ().isHalfway && scoring && player.GetComponent<Rigidbody> ().velocity.magnitude > 0.10) 
//		{
//			score = 100 - 100 * (Vector3.Distance (player.transform.position, flag.transform.position) / Vector3.Distance (middle.transform.position, flag.transform.position));
//		}
			
		if (playerCam.GetComponent<CamController> ().isHalfway && scoring && player.GetComponent<Rigidbody> ().velocity.magnitude < 0.10)
		{
			score = 100 - 100 * (Vector3.Distance (player.transform.position, flag.transform.position) / Vector3.Distance (middle.transform.position, flag.transform.position));
			player.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			player.GetComponent<Rigidbody> ().Sleep ();
			StartCoroutine (Wait ());

		}


			
		
	}

	void OnTriggerEnter()
	{
		ToggleScoring ();
	}


	public void ToggleScoring()
	{
		scoring = !scoring;
	}

	IEnumerator Wait()
	{
		ToggleScoring ();
		yield return new WaitForSeconds (2);
		playerCam.GetComponent<CamController> ().HalfwaySwitch();

	}


}
