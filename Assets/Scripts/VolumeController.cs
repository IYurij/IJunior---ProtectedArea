using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0.001f, 0.1f)] private float _volumeStep;

    private float _currentVolume;
    private readonly float _maxVolume = 1f;
    private readonly float _minVolume = 0;

    public void ChangeVolume(bool isInvasion)
    {   
        StopAllCoroutines();

        if (isInvasion == true)
        {
            StartCoroutine(UpVolume());
        }
        else
        {
            StartCoroutine(DownVolume());
        }
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator UpVolume()
    {
        _audioSource.Play();

        while (_currentVolume < _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, _volumeStep);
            _currentVolume = _audioSource.volume;

            yield return null;
        }
    }

    private IEnumerator DownVolume()
    {
        while (_currentVolume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, _minVolume, _volumeStep);
            _currentVolume = _audioSource.volume;

            yield return null;
        }
        _audioSource.Stop();
    }
}
