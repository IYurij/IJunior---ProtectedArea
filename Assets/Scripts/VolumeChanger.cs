using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField, Range(0.001f, 0.1f)] private float _volumeStep;

    private float _currentVolume;
    private float _volumeLevel;
    private readonly float _maxVolume = 1f;
    private readonly float _minVolume = 0;

    public void ChangeVolume(bool isInvasion)
    {   
        if (_currentVolume == 0)
        {
            if (isInvasion)
            {
                _audioSource.Play();
            }
            else
            {
                _audioSource.Stop();
            }
        }

        StopCoroutine(ChangeVolumeCorutine());

        _volumeLevel = isInvasion ? _maxVolume : _minVolume;

        StartCoroutine(ChangeVolumeCorutine());
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator ChangeVolumeCorutine()
    {
        while (_currentVolume < _volumeLevel || _currentVolume > _volumeLevel)
        {
            _audioSource.volume = Mathf.MoveTowards(_currentVolume, _volumeLevel, _volumeStep);
            _currentVolume = _audioSource.volume;

            yield return null;
        }
    }
}
