using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float ySpeed = 2;
    public float rSpeed = 10;
    Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {

        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * Time.deltaTime * ySpeed, ForceMode2D.Force);
        }
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * Time.deltaTime * rSpeed);

	}
}
