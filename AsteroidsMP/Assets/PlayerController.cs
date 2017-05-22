using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public Projectile projectile;
    public float ySpeed = 2;
    public float rSpeed = 10;
    Rigidbody2D rb;
    public Text scoreText;
    [SyncVar(hook = "OnScoreChanged")]
    public int score = 0;
    NetworkStartPosition[] startPositions;
    bool vulnerable = true;
    public float invulnerableDuration = 2;

    public IEnumerator Invulnerable()
    {
        vulnerable = false;
        yield return new WaitForSeconds(invulnerableDuration);
        vulnerable = true;
    }


    private void Start()
    {
        StartCoroutine(Invulnerable());
    }

    public override void OnStartLocalPlayer()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.GetComponent<SpriteRenderer>().color = Color.green;
        scoreText.color = Color.red;
        if (isLocalPlayer) startPositions = FindObjectsOfType<NetworkStartPosition>();
	}
	
	void Update () {

        if (!isLocalPlayer) return;

        var vertical = Input.GetAxis("Vertical");
        if (vertical > 0)
        {
            rb.AddForce(transform.up * Time.deltaTime * ySpeed, ForceMode2D.Force);
        }
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * Time.deltaTime * rSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdLaunch();
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isServer) return;
        if (collision.GetComponent<Asteroid>() != null && vulnerable)
        {
            score = 0;
            StartCoroutine(Invulnerable());
            RpcRespawn();
        }
    }

    [Command]
    public void CmdLaunch()
    {
        if (!isServer) return;
        var go = Instantiate(projectile, transform.position, transform.rotation);
        go.GetComponent<Rigidbody2D>().velocity = transform.up * projectile.velocity;
        go.origin = this;
        NetworkServer.Spawn(go.gameObject);
        Destroy(go.gameObject, projectile.alive);
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        var pos = startPositions[Random.Range(0, startPositions.Length)].transform.position;
        rb.position = pos;
        rb.rotation = 0;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void OnScoreChanged(int score)
    {
        scoreText.text = score + "";
    }

}
