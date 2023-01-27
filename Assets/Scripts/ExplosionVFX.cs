using System.Threading;
using Alteruna;
using UnityEngine;

public class ExplosionVFX : AttributesSync
{
    
    [SerializeField]
    private ParticleSystem particleSystem;

    [SerializeField] private float lifeTime = 0.17f;
    
    private Mach.Spawner _spawner;
    private float _timer = 0.0f;

    private void Start()
    {
        _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mach.Spawner>();
    }

    private void Update()
    {
        _timer += 1.0f * Time.deltaTime;
        if (_timer >= lifeTime)
        {
            _spawner.Despawn(gameObject);
        }
    }

    public void PlayVFX(uint seed, float rotation)
    {
        BroadcastRemoteMethod("PlayVFXInternal", seed, rotation);
    }

    [SynchronizableMethod]
    private void PlayVFXInternal(uint seed, float rotation)
    {
        particleSystem.randomSeed = seed;
        particleSystem.subEmitters.GetSubEmitterSystem(0).randomSeed = seed;
        ParticleSystem.ShapeModule shape = particleSystem.subEmitters.GetSubEmitterSystem(0).shape;
        shape.rotation = new Vector3(0.0f, 0.0f, rotation);

        particleSystem.Play();
    }
}
