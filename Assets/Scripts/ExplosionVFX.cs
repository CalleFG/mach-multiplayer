using Alteruna;
using UnityEngine;

public class ExplosionVFX : AttributesSync
{
    
    [SerializeField]
    private ParticleSystem particleSystem;

    private Mach.Spawner _spawner;

    private bool _isInitiated = false;

    private void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mach.Spawner>();
    }

    private void Update()
    {
        if (_isInitiated == false) { return; }
        
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
        
        _isInitiated = true;
    }
}
