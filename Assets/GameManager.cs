using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
        public Playerscript player;
    private Vector3 startPosition;
    public Text scoreText;
    public GameObject playButton;
    public Text gameOver;
    private const float Speed = 5f;
    private int score;

    private void Awake() {
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.text = "";

        Time.timeScale = 1f;
        player.enabled = true;
        startPosition = new Vector3(-3, 5, 0);
        player.transform.position = startPosition;
        player.dragonRigidbody2D.velocity = Vector2.up * Speed;

        taggar[] taggar = FindObjectsOfType<taggar>();

        for (int i =0; i < taggar.Length; i++) {
            Destroy(taggar[i].gameObject);
        }
    }   
     public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver() {
        gameOver.text = "GAME OVER";
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}