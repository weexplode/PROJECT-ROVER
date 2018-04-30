using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Activatable {

    public ScriptedEvents controller;
    public int num;

	public override string Activate()
    {
        return controller.ButtonPress(num, GetComponentInChildren<Light>());
    }
}
