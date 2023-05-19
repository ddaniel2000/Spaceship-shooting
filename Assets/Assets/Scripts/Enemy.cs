using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _deathVFX;

    [SerializeField] private int _score;
    private int hitPoint;
    
    public static Action<int> OnScoreIncrese;
    private bool _canTakeHit = true;

    private void Start()
    {
        hitPoint = _score;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        
    }

    private void ProcessHits()
    { 
        hitPoint--;
        if(hitPoint <= 0 && _canTakeHit)
        {
            OnScoreIncrese?.Invoke(_score);
            KillEnemy();
            _canTakeHit = false;
        }
        
    }

    private void KillEnemy()
    {

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
