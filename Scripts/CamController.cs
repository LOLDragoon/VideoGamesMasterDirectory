using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    public GameObject ball;
	public bool isHalfway = false;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - ball.transform.position;
    }

    void LateUpdate()
    {
		if (isHalfway) {
			transform.position = new Vector3(ball.transform.position.x+offset.x,ball.transform.position.y+offset.y,ball.transform.position.z - 2*offset.z);
			transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
			
		} else {
			transform.position = ball.transform.position + offset;
			transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
		}
    }


	public void HalfwaySwitch()
	{
		isHalfway = !isHalfway;
	}
}
