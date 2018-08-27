using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMovement : MonoBehaviour {

    //int habilityCounter = 0;
    public bool activatePlatform;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        MagicPower();
	}

    void MagicPower()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!activatePlatform)
                activatePlatform = true;
            else
                activatePlatform = false;
        }
    }
}
