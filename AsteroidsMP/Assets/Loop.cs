using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour {

    Rigidbody2D rb;
    Camera cam;
    [HideInInspector]
    public float hLimit;
    [HideInInspector]
    public float vLimit;
    public float cushion = 1;
    public float delay = 0.3f;

	void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        var limitVec = cam.ScreenToWorldPoint(Vector2.zero) * -1;
        hLimit = limitVec.x + cushion;
        vLimit = limitVec.y + cushion;
        StartCoroutine(Looping());
    }

    IEnumerator Looping()
    {
        for (;;)
        {
            if (transform.position.x < -hLimit)
            {
                rb.MovePosition(new Vector2(hLimit, transform.position.y));
            }
            else if (transform.position.x > hLimit)
            {
                rb.MovePosition(new Vector2(-hLimit, transform.position.y));
            }

            if (transform.position.y < -vLimit)
            {
                rb.MovePosition(new Vector2(transform.position.x, vLimit));
            }
            else if (transform.position.y > vLimit)
            {
                rb.MovePosition(new Vector2(transform.position.x, -vLimit));
            }
            yield return new WaitForSeconds(delay);
        }
    }
	
	void Update () {

     



    }
}
