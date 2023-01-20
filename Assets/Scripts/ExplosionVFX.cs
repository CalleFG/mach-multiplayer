using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    
    [SerializeField]
    private ParticleSystem particleSystem;

    private Alteruna.Spawner _spawner;
    private void Update()
    {
        if (particleSystem.isStopped)
        {
             _spawner.Despawn(gameObject);
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
    }
}
