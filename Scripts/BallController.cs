using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public const float triggerSpeed = 8.0f;
    public Transform loadPoint;
    public Vector3 movement;
    public float moveSpeed;
	public Slider slider;

	public float breathPower;

    public Text speedValue;
    public Text stateValue;

	void Awake(){
		
	}

    void FixedUpdate()
    {
        

		breathPower = Input.GetAxis ("Vertical");
		print (breathPower);


		Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        Vector3 forwardForce = new Vector3();
        forwardForce = forward * Input.GetAxis("Vertical") * moveSpeed;
        GetComponent<Rigidbody>().AddForce(forwardForce);


		slider.value = breathPower;
	

        speedValue.text = GetComponent<Rigidbody>().velocity.magnitude.ToString("0.###");
        if (GetComponent<Rigidbody>().velocity.magnitude >= triggerSpeed)
        {
            stateValue.text = "Pass";
        }
        else
        {
            stateValue.text = "Failed";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillBox")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.position = loadPoint.position;
        }
    }
}
