using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Canvas startScreen, uiMap, endScreen;
    public AudioSource gameMusic, ocaenSound, winSound, loseSound;
    public GameObject boat;
    private bool gameOver = false;

    void Start() {
        Time.timeScale = 0;
        uiMap.enabled = false;
        endScreen.enabled = false;
        ocaenSound.Play();
        gameOver = false;
    }


    void Update() {
        
    }

    public void StartGame() {
        Time.timeScale = 1;
        uiMap.enabled = true;
        startScreen.enabled = false;
        gameMusic.Play();
        ocaenSound.Stop();
    }

    public void LoseCondition() {
        gameMusic.Stop();
        loseSound.Play();
        StartCoroutine(RestartGame(5f));
        boat.GetComponent<BoatHealth>().alive = false;
        boat.GetComponent<BoatHealth>().BoadDeathFace();
        gameOver = true;
    }

    public void WinCondition() {

        if (!gameOver) {
            endScreen.enabled = true;
            uiMap.enabled = false;
            gameMusic.Stop();
            StartCoroutine(PlayWinSound());
            StartCoroutine(RestartGame(5f));
        }

    }

    IEnumerator RestartGame(float time) {

        yield return new WaitForSeconds(time);

        Scene levelToLoad = SceneManager.GetActiveScene();
        SceneManager.LoadScene(levelToLoad.buildIndex);
    }

    IEnumerator PlayWinSound() {
        yield return new WaitForSeconds(2.25f);
        winSound.Play();
    }
}
