using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraBehavior : MonoBehaviour {

    public GameObject player;

    public void EnablePlayerMovement()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        GetComponent<Animator>().enabled = false;
        GetComponent<SmoothFollow>().enabled = true;
    }
}
