using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBreathZoneTrigger : MonoBehaviour {

    public static bool isTriggerOn = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isTriggerOn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            isTriggerOn = false;
        }
    }
}
