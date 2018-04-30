using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectable : MonoBehaviour {

    public File[] files;

    public virtual void Startup(Console console)
    {

    }

    public void Connect(Console console)
    {
        console.connected = this;
        Startup(console);
    }

    public void Disconnect(Console console)
    {
        console.connected = null;
    }
}

public class File {
    public string name;
    public string contents;
}
