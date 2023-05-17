using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _deathVFX;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"{name} I'm hit! by {other.gameObject.name}");
        DeathSequence();
        Destroy(gameObject, 0);
    }

    private void DeathSequence()
    {
        foreach (GameObject particle in _deathVFX)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
        }
        
    }
}
