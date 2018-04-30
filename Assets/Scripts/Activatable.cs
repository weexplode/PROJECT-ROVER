using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : Connectable {

	public virtual string Activate()
    {
        return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Console console = player.console.GetComponent<Console>();
            if (console.connected == null)
                Connect(console);
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
        }
    }

}
