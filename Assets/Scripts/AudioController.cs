using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0.001f, 0.1f)] private float _volumeStep;

    private float _currentVolume;

    private void Start()
    {
        _audioSource.volume = 0; 
    }
    // Update is called once per frame
    private void Update()
    {
        _currentVolume = _audioSource.volume;

        if (_currentVolume < 1)
        {
            _audioSource.volume += _volumeStep;
        }
    }
}
