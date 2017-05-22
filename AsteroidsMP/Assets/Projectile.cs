using UnityEngine;
using UnityEngine.Networking;

public class Projectile : NetworkBehaviour {


    public float velocity = 10;
    public float alive = 2;
    public PlayerController origin;


    //public void Launch(Transform origin)
    //{
    //    if (!isServer) return;
    //    var go = Instantiate(this, origin.position, origin.rotation);
    //    go.GetComponent<Rigidbody2D>().velocity = origin.up * velocity;
    //    go.origin = origin.GetComponent<PlayerController>();
    //    NetworkServer.Spawn(go.gameObject);
    //    Destroy(go.gameObject, alive);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            Destroy(gameObject);
            if (isServer) origin.IncrementScore();
        }
    }

}
