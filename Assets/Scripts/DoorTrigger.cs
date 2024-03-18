using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorControl doorControl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            doorControl.Operate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            doorControl.Operate();
        }
    }
}
