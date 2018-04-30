using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class CameraBehavior : MonoBehaviour {

    public GameObject player;
    public GameObject gameController;

    public void EnablePlayerMovement()
    {
        player.GetComponent<PlayerController>().enabled = true;
        GetComponent<Animator>().enabled = false;
        GetComponent<SmoothFollow>().enabled = true;
        player.GetComponent<PlayerController>().console.SetActive(true);
        gameController.SetActive(true);
    }
}
