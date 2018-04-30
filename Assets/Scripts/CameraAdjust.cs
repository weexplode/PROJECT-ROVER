using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraAdjust : MonoBehaviour {

    public float height = 2f;
    public SmoothFollow follow;

    float oldHeight;

    private void OnTriggerEnter(Collider other)
    {
        if(oldHeight == 0)
            oldHeight = follow.height;
        follow.height = height;

    }

    private void OnTriggerExit(Collider other)
    {
        if(oldHeight != 0)
            follow.height = oldHeight;
        oldHeight = 0;
    }
}
