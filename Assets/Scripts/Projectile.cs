using Alteruna;
using UnityEngine;

public class Projectile : AttributesSync
{
    private Mach.Spawner _spawner;
    private Transform _transform;
    private float _projectileSpeed = 0.005f;
    private int _instigatorID = -1;
    public bool isReal = false;

    private void Start()
    {
        _transform = transform;
        _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mach.Spawner>();
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector3.right * _projectileSpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!isReal) return;
        
        Hittable hittable = col.gameObject.GetComponent<Hittable>();
        if (hittable)
        {
            hittable.Hit(_instigatorID);
        }

        GameObject obj = _spawner.Spawn(1, _transform.position, _transform.rotation);
        ExplosionVFX vfx = obj.GetComponent<ExplosionVFX>();
        float angle = Vector2.SignedAngle(Vector2.up, col.GetContact(0).normal) * -1;
        vfx.PlayVFX(12, new Vector3(0.0f, 0.0f, angle));

        _spawner.Despawn(gameObject);
    }

    public void InitializeProjectile(int id, float speed)
    {
        BroadcastRemoteMethod("InitializeSync", id, speed);
    }
    
    [SynchronizableMethod]
    private void InitializeSync(int id, float speed)
    {
        _projectileSpeed = speed;
        _instigatorID = id;
    }
}
