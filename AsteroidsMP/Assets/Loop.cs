using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Loop : NetworkBehaviour {

    public float cushion = 1;
    public float delay = 0.3f;

	void Start() {
        if (isLocalPlayer || isServer) StartCoroutine(Looping());
    }

    IEnumerator Looping()
    {
        for (;;)
        {
            var rb = GetComponent<Rigidbody2D>();
            var xy = Utility.SpawnArea(cushion);

            if (transform.position.x < -xy.x)
            {
                rb.MovePosition(new Vector2(xy.x, transform.position.y));
            }
            else if (transform.position.x > xy.x)
            {
                rb.MovePosition(new Vector2(-xy.x, transform.position.y));
            }

            if (transform.position.y < -xy.y)
            {
                rb.MovePosition(new Vector2(transform.position.x, xy.y));
            }
            else if (transform.position.y > xy.y)
            {
                rb.MovePosition(new Vector2(transform.position.x, -xy.y));
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
