using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour {

    public Text[] textManager = new Text[5];

    private void SetMessage()
    {
        textManager[0].text = "Use your breath to break the wall!";


        textManager[1].text = "Good work! You can relax and breathe normally.";


        textManager[2].text = "Go to the next challenge!";


        textManager[3].text = "Be caraful not to fall!";


        textManager[4].text = "Warp directly to your next challenge?";
    }
}
