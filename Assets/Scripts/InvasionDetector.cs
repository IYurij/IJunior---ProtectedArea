using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvasionDetector : MonoBehaviour
{
    [SerializeField] private UnityEvent _invasionIn;
    [SerializeField] private UnityEvent _invasionOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _invasionIn?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            _invasionOut?.Invoke();
        }
    }
}
