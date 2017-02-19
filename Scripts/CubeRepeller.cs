using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRepeller : MonoBehaviour {

    public float attractionForce;
    public GameObject[] cubes;

//    Rigidbody body;
//
//    void Awake()
//    {
//        body = GetComponent<Rigidbody>();
//    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball" && BigBreathZoneTrigger.isTriggerOn == true)
        {
			if (Input.GetAxis("Vertical")>.5)
            {
                foreach (GameObject cube in cubes)
				{
					cube.GetComponent<Rigidbody>().AddForce(transform.forward * attractionForce, ForceMode.Impulse);
					cube.GetComponent<Rigidbody> ().AddForce (transform.up * attractionForce, ForceMode.Impulse);
                    StartCoroutine(deactivator());
                }
            }
        }
    }

    IEnumerator deactivator()
	{   
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].SetActive(false);
        }
    }
}
