using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {


    public float velocity = 10;
    public float alive = 2;
    PlayerController origin;


    public Projectile Launch(Transform origin)
    {
        var go = Instantiate(this, origin.position, origin.rotation);
        go.GetComponent<Rigidbody2D>().velocity = origin.up * velocity;
        go.origin = origin.GetComponent<PlayerController>();
        //go.audio.Play();
        Destroy(go.gameObject, alive);
        return go;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            origin.IncrementScore();
            Destroy(gameObject);
        }
    }

}
