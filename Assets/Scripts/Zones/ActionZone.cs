using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionZone : MonoBehaviour
{
    public UnityEvent ActionEnter;
    public UnityEvent ActionExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActionEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ActionExit.Invoke();
        }
    }
}
