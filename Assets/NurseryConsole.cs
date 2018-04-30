using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseryConsole : ConsoleScreen {

	// Use this for initialization
	void Start () {
        files = new File[]
        {
            new File() { name = "ac0f27", contents = "FILE CORRUPTED"},
            new File() { name = "Valve Order", contents = "Three.\nOne.\nTwo."},
            new File() { name = "3ec802", contents = "FILE CORRUPTED"},
            new File() { name = "00110100", contents = "01001000 01000101 01001100 01001100 01001111"}
        };
	}
	
    public override void Startup(Console console)
    {
        console.PrintLine("Connected to Nursery Console A.");
    }
}
