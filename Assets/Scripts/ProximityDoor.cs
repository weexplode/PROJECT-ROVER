using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDoor : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Animator>().SetBool("character_nearby", true);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Animator>().SetBool("character_nearby", false);
    }
}
