using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bloop : MonoBehaviour {

    public float bloopInterval;

    bool currentBloop = false;
    float currentTime = 0;

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            currentBloop = !currentBloop;
            currentTime = bloopInterval;
            GetComponent<Image>().color = (currentBloop ? Color.red : Color.black);
        }
    }

    private void OnDisable()
    {
        GetComponent<Image>().color = Color.black;
    }
}
