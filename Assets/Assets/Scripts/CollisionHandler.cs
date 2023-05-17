using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Header("Ship Controls")]
    [SerializeField] private PlayerShipMovement _shipControls;

    [Header("Load Level Delay")]
    [SerializeField] private int _loadLevelDelay;

    [Header("Ship Crash VFX")]
    [SerializeField] private ParticleSystem[] _explosionParticle;
    [SerializeField] private AudioSource _explosionSound;

    [Header("Ship Mesh")]
    [SerializeField] private GameObject _planeMesh;
    private BoxCollider _planeCollider;

    private void Start()
    {
        _planeCollider = GetComponent<BoxCollider>();
        _shipControls = GetComponent<PlayerShipMovement>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCrashSequence();
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        _shipControls.enabled = false;

        foreach(ParticleSystem particle in _explosionParticle)
        {
            particle.Play();
        }    
        _explosionSound.Play();
        _planeMesh.SetActive(false);
        _planeCollider.enabled = false;
        Invoke("ReloadLevel", _loadLevelDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}
