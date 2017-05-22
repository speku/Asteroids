using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public float explosionDuration = 1;
    SpriteRenderer sr;
    ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        sr = GetComponent<SpriteRenderer>();
    }

    public IEnumerator Explode()
    {
        sr.enabled = false;
        gameObject.SetActive(false);
        ps.Play();
        yield return new WaitForSeconds(explosionDuration);
        ps.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Projectile>() != null){
            StartCoroutine(Explode());
        }
    }
}
