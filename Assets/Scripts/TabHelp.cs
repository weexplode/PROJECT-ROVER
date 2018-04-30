using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabHelp : MonoBehaviour {

    public float delay = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        if (delay < 0)
            GetComponent<Text>().enabled = true;
	}
}
