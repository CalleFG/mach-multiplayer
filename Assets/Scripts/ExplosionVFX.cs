using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    
    [SerializeField]
    private ParticleSystem particleSystem;

    private bool _isInitiated = false;
    
    
    private void Update()
    {
        if (_isInitiated == false) { return; }
        
        if (particleSystem.isStopped)
        {

        }
    }

    public void PlayVFX(uint seed, Vector3 rotation)
    {
        // Explosion
        particleSystem.randomSeed = seed;
        // Parts
        particleSystem.subEmitters.GetSubEmitterSystem(0).randomSeed = seed;
        ParticleSystem.ShapeModule shape = particleSystem.subEmitters.GetSubEmitterSystem(0).shape;
        shape.rotation = rotation * -1;

        particleSystem.Play();
        
        _isInitiated = true;
    }
}
