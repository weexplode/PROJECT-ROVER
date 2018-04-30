using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotifyParent : MonoBehaviour {

    public string notify;

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<ScriptedEvents>().Trigger(notify);
    }
}
