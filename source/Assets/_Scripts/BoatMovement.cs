using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour {

    public float moveSpeed = 1.5f;
    public float dropAmount = 0.4f;
    public float sinkSpeed = 0.25f;
    public float riseAmount = 0.075f;
    public bool boatSinking = false;
    public GameManager gameManager;

    void Start() {
        
    }


    void Update() {
        if (boatSinking) {
            this.transform.position += ((-transform.up) * sinkSpeed) * Time.deltaTime;
        }

        if (this.transform.position.x <= 64f) {
            this.transform.position += (transform.right * moveSpeed) * Time.deltaTime;
        } else {
            boatSinking = false;
            gameManager.WinCondition();
        }
        
    }

    public void DropBoat() {
        this.transform.position = new Vector2(transform.position.x, transform.position.y - dropAmount);
    }

    public void RaiseBoat() {
        this.transform.position = new Vector2(transform.position.x, transform.position.y + riseAmount);
    }

    public void LoseAnvil() {
        this.transform.position = new Vector2(transform.position.x, transform.position.y + dropAmount + 0.2f);
    }
}
