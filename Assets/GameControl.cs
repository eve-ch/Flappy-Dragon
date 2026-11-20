using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
        public Playerscript player;
    Spawner spawner;
    private Vector3 startPosition;
    public Text scoreText;
    public GameObject playButton;
    public Text gameOver;
    public GameObject mainMenuButton;
    public GameObject instructionsButton;
    public Text instructionsText;
    public Text titleText;
    public GameObject hardButton;
    public GameObject easyButton;
    public GameObject quitButton;
    private const float Speed = 5f;
    private int score;
    AudioSource scoreSound;

    private void Start() {
        scoreSound = GetComponent<AudioSource>();
    }

    private void Awake() {
        Pause();
        MainMenu();
        Easy();

    }

    public void MainMenu() {
        titleText.text = "Flappy Little Dragon";
        instructionsButton.SetActive(true);
        instructionsText.text = "<3";
        playButton.SetActive(true);
        gameOver.text = "";
        mainMenuButton.SetActive(false);
        hardButton.SetActive(true);
        easyButton.SetActive(true);

        startPosition = new Vector3(-3, 5, 0);
        player.transform.position = startPosition;

        taggar[] taggar = FindObjectsOfType<taggar>();

        for (int i =0; i < taggar.Length; i++) {
            Destroy(taggar[i].gameObject);
        }
    
    }

    public void Instructions() {
        instructionsButton.SetActive(false);
        hardButton.SetActive(false);
        easyButton.SetActive(false);
        titleText.text = "";
        playButton.SetActive(false);
        mainMenuButton.SetActive(true);
        instructionsText.text = "Press SPACE or left mouse click to fly, Avoid the spikes and ground or else you will die, Try collect the eggs on the way to get extra points, you can see your score at the top of the screen, Good luck and have fun!";
    }

    public void Hard() {
        FindObjectOfType<Spawner>().FastSpawn();
    }
    public void Easy() {
        FindObjectOfType<Spawner>().SlowSpawn();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        instructionsButton.SetActive(false);
        mainMenuButton.SetActive(false);
        hardButton.SetActive(false);
        easyButton.SetActive(false);
        gameOver.text = "";
        titleText.text = "";
        instructionsText.text = "";

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
        mainMenuButton.SetActive(true);
        Pause();
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
        scoreSound.Play();
    }

    public void IncreaseScoreEggs() {
        score += 3;
        scoreText.text = score.ToString();
        scoreSound.Play();
    }
}