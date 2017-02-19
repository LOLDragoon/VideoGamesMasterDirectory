using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

	public GameObject[] tileTypes; // these are the different tiles
	public GameObject connector; // these link the stages
	public GameObject bigBreath; // These are the tiles that specifically are used for the testing.
	public int minTiles;
	public int maxTiles;
	private int stageLength;
	private int bSPPointer = 0;
	private Transform[] breathStartPoints;
	public int totalScore;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			DestroyImmediate(this);
		}
	}

	private static GameController instance;
	public static GameController Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameController();
			}
			return instance;
		}
	}

	// Use this for initialization
	void Start () 
	{
		breathStartPoints = new Transform[3];
		MakeStageLength ();
		ConstructStage ();
		bSPPointer = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void MakeStageLength()
	{
		stageLength = Random.Range (minTiles, maxTiles);

		print (stageLength);

		if (stageLength%2 > 0)
		{
			stageLength += 1;
		}

		print(stageLength);
	}

	void ConstructStage()
	{
		GameObject currentTile = (GameObject)Instantiate(bigBreath,Vector3.zero,Quaternion.identity);
		breathStartPoints[bSPPointer] = currentTile.transform.Find ("Breath Start");
		bSPPointer++;    //move pointer on the array up in order to list start points of breathing exercises
		Transform endPoint =  currentTile.transform.Find("End Attach Point");

		for (int i = 1; i <= stageLength; i++)
		{
			currentTile = (GameObject)Instantiate(connector,endPoint.position,endPoint.rotation);
			endPoint = currentTile.transform.Find("End Attach Point");

			if (i == stageLength / 2 || i == stageLength) {
				
				currentTile = (GameObject)Instantiate (tileTypes [Random.Range (0, tileTypes.Length)], endPoint.position, endPoint.rotation);
				endPoint = currentTile.transform.Find ("End Attach Point");

				currentTile = (GameObject)Instantiate(connector,endPoint.position,endPoint.rotation);
				endPoint = currentTile.transform.Find("End Attach Point");

				currentTile = (GameObject)Instantiate (bigBreath, endPoint.position, endPoint.rotation);
				breathStartPoints[bSPPointer] = currentTile.transform.Find ("Breath Start");
				bSPPointer++;    //move pointer on the array up in order to list start points of breathing exercises
				endPoint = currentTile.transform.Find ("End Attach Point");
			} 
			else 
			{
				currentTile = (GameObject)Instantiate (tileTypes [Random.Range (0, tileTypes.Length)], endPoint.position, endPoint.rotation);
				endPoint = currentTile.transform.Find ("End Attach Point");
			}

		}
			
	}

	public void MoveBSPPointer()
	{
		if (bSPPointer<3)
		{
		bSPPointer++;
		}
	}



}
