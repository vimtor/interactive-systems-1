using System;
using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private BoxCollider _boxCollider;
    private AudioSource _audioSource;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _boxCollider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _meshRenderer.enabled = false;
            _boxCollider.enabled = false;

            _audioSource.Play();

            EventManager.PickedUp.Invoke();

            Destroy(gameObject, _audioSource.clip.length);
        }
    }
}