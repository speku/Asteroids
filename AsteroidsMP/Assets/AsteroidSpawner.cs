using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AsteroidSpawner : MonoBehaviour {

    public int max = 5;
    public int min = 2;
    public float velocityMax = 3;
    public float velocityMin = 1;
    public float delay = 2;
    public GameObject asteroid;
    public float cushion = 0.1f;

    List<GameObject> asteroids;

	void Start () {
        asteroids = Enumerable.Range(0, max).Select(_ => Spawn()).ToList();
        //StartCoroutine(Respawn());
	}

    void Setup(GameObject go)
    {
        go.SetActive(true);
        go.GetComponent<SpriteRenderer>().enabled = true;
        var rb = go.GetComponent<Rigidbody2D>();
        var xy = Utility.SpawnArea(cushion);
        rb.position = new Vector2(Random.Range(-xy.x, xy.x), (Random.value <= 0.5 ? -1 : 1) * xy.y);
        rb.rotation = Random.Range(0, 180);
        go.GetComponent<Rigidbody2D>().velocity = go.transform.up * Random.Range(velocityMin, velocityMax);
     
    }

    GameObject Spawn()
    {
        var xy = Utility.SpawnArea(cushion);
        var go = Instantiate(asteroid, new Vector2(Random.Range(-xy.x, xy.x), (Random.value <= 0.5 ? -1 : 1) * xy.y), Quaternion.Euler(0, 0, Random.Range(0, 180)));
        Setup(go);
        return go;
    }

    IEnumerator Respawn()
    {
        for (;;)
        {
            asteroids.Where(x => !x.activeSelf).ToList().ForEach(x => Setup(x));
        }
    }
	
}
