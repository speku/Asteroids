using UnityEngine;
using UnityEngine.Networking;

public class AsteroidSpawner : NetworkBehaviour {

    public int max = 5;
    public int min = 2;
    public float velocityMax = 3;
    public float velocityMin = 1;
    public float delay = 2;
    public GameObject asteroid;
    public float cushion = 0.1f;

	public override void OnStartServer () {
        for (var i = 1; i <= max; i++) Spawn();
	}

    public void Spawn(GameObject prefab = null, Transform trans = null)
    {
        if (!isServer) return;
        var xy = Utility.SpawnArea(cushion);
        var go = Instantiate(prefab ?? asteroid, trans == null ? new Vector2(Random.Range(-xy.x, xy.x), (Random.value <= 0.5 ? -1 : 1) * xy.y) : (Vector2) trans.position, Quaternion.Euler(0, 0, Random.Range(0, 180)));
        go.GetComponent<Rigidbody2D>().velocity = go.transform.up * Random.Range(velocityMin, velocityMax);
        go.GetComponent<Asteroid>().spawner = this;
        NetworkServer.Spawn(go);
    }
	
}
