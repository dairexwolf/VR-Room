using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class SBallSound : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;

    [SerializeField]
    [Tooltip("Playing sound")]
    private AudioClip AudioClip;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float volume;
        if (_rigidbody.velocity.magnitude > 10f)
            volume = 1f;
        else if (_rigidbody.velocity.magnitude < 10f && _rigidbody.velocity.magnitude > 1f)
            volume = _rigidbody.velocity.magnitude / 10f;
        else
            volume = 0f;
        _audioSource.PlayOneShot(AudioClip, volume);
    }

    private void OnValidate()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }
}
