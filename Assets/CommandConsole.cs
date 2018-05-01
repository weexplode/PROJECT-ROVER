using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandConsole : Activatable {

    private void Start()
    {
        files = new File[]
        {
            new File() { name = "0100", contents = "2f" },
            new File() { name = "0001", contents = "82" },
            new File() { name = "0011", contents = "4c" },
            new File() { name = "0010", contents = "a8" }
        };
    }

    public override void Startup(Console console)
    {
        console.PrintLine("Connected to Command Console.\nThis console seems to have a special function.\nTry 'activate' to use it.");
    }

    public override string Activate(string arg)
    {
        if(arg == null)
        {
            return "Activation requires password.\nPlease enter in the format 'activate <password>'";
        } else if(arg == "82a84c2f")
        {
            GameObject.Find("GameController").GetComponent<ScriptedEvents>().FadeToBlack();
            return "Access granted.";
        } else
        {
            return "Password incorrect.";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            Console console = player.console.GetComponent<Console>();
            if (console.connected == null)
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
