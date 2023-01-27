using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class SBallSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rigidbody.velocity.magnitude < 10f && _rigidbody.velocity.magnitude > 1f)
            _audioSource.volume = _rigidbody.velocity.magnitude / 10f;
        else if (_rigidbody.velocity.magnitude > 10f)
            _audioSource.volume = 1f;
        else
            _audioSource.volume = 0f;
        _audioSource.Play();
    }
}
