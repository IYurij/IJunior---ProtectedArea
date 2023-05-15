using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvasionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " Was entered!");
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
