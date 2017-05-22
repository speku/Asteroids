using UnityEngine;
using UnityEngine.Networking;

public class Asteroid : NetworkBehaviour {

    public float explosionDuration = 1;
    [HideInInspector]
    public AsteroidSpawner spawner;
    public GameObject smallAsteroid;
    public bool small = false;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Explode()
    {
        Destroy(gameObject);
        if (isServer && !small)
        {
            spawner.Spawn();
            spawner.Spawn(smallAsteroid, transform);
            spawner.Spawn(smallAsteroid, transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() != null){
            Explode();
        }
    }
}
