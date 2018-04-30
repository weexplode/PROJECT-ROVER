using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleScreen : Connectable {

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Console console = player.console.GetComponent<Console>();
            if(console.connected == null)
                Connect(console);
            GetComponent<MeshRenderer>().materials[1].color = new Color(0, 118, 255);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Console console = player.console.GetComponent<Console>();
            if (console.connected != null)
                Disconnect(console);
            GetComponent<MeshRenderer>().materials[1].color = new Color(0, 0, 0);
        }
    }
}
