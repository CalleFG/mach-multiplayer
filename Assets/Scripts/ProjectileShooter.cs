using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    private Alteruna.Avatar _avatar;
    private Mach.Spawner _spawner;
    
    private bool _canFire = true;
    private float _timer = 0.0f;
    
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float projectileSpeed = 0.005f;
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private int indexToSpawn = 0;
    
    private void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        _spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Mach.Spawner>();
    }
    
    private void Update()
    {
        if (!_avatar.IsMe) return;
        
        if (!_canFire)
        {
            _timer += 1.0f * Time.deltaTime;
            if (_timer >= cooldown)
            {
                _canFire = true;
                _timer = 0.0f;
            }
        }

        if (Input.GetMouseButton(0) && _canFire)
        {
            _canFire = false;
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        GameObject obj = _spawner.Spawn(indexToSpawn, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Projectile projectile = obj.GetComponent<Projectile>();
        projectile.InitializeProjectile(_avatar.Possessor.Index, projectileSpeed);
        projectile.isReal = true;
    }
}

