using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject console;
    public Transform consoleOff;
    public Transform consoleOn;
    public GameObject indicatorTab;

    bool transitioning;
    Transform transitionTransform;
    Vector3 transitionTarget;
    Vector3 transitionOrigin;
    float transitionRate;

    public bool consoleEnabled = false;

	// Use this for initialization
	void Start () {
        GetComponent<PlayerMovement>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (transitioning && (transitionTransform.position = Vector3.Lerp(transitionOrigin, transitionTarget, ((transitionTransform.position - transitionOrigin).magnitude / (transitionTarget - transitionOrigin).magnitude) + Time.deltaTime * transitionRate)) == transitionTarget)
        {
            console.GetComponentInChildren<InputField>().interactable = consoleEnabled;
            if (consoleEnabled) console.GetComponentInChildren<InputField>().Select();
            transitioning = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                console.GetComponentInChildren<InputField>().text = "";
                consoleEnabled = !consoleEnabled;
                BeginTransition(console.transform, consoleEnabled ? consoleOn.position : consoleOff.position, 3);
                GetComponent<PlayerMovement>().enabled = !consoleEnabled;
                indicatorTab.transform.Find("TabText").gameObject.SetActive(false);
                indicatorTab.transform.Find("Bloop Indicator").GetComponent<Bloop>().enabled = false;
            }
        }
	}

    public void BeginTransition(Transform tr, Vector3 targ, float rate)
    {
        transitioning = true;
        transitionTransform = tr;
        transitionOrigin = tr.position;
        transitionTarget = targ;
        transitionRate = rate;
    }
}
