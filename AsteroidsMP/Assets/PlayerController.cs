using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Projectile projectile;
    public float ySpeed = 2;
    public float rSpeed = 10;
    Rigidbody2D rb;
    public Text scoreText;
    public int score = 0;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectile.Launch(transform);
        }

	}

    public void IncrementScore()
    {
        score++;
        scoreText.text = score + "";
    }

}
