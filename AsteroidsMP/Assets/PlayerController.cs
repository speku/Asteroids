using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float ySpeed = 2;
    public float rSpeed = 10;
    public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * Time.deltaTime * ySpeed, ForceMode2D.Force);
        }
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * Time.deltaTime * rSpeed);

	}
}
