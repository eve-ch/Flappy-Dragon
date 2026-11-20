using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    private const float Speed = 10f;
    public Rigidbody2D dragonRigidbody2D;
    private bool goingUp;
    AudioSource wingSound;

    // Start is called before the first frame update
    void Start()
    {
        dragonRigidbody2D = GetComponent<Rigidbody2D>();
        wingSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            goingUp = true;
        }
    }
    
    void FixedUpdate() {
        if (goingUp) {
        dragonRigidbody2D.velocity = Vector2.up * Speed;
        wingSound.Play();
        goingUp = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameControl>().GameOver();
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameControl>().IncreaseScore();
        } else if (other.gameObject.tag == "Eggs") {
            FindObjectOfType<GameControl>().IncreaseScoreEggs();
        }

        if (other.tag == "Eggs") {
            Destroy(other.gameObject);
        }
    }
}
