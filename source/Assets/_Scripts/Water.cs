using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

    public CameraMovement cameraMovement;
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Boat"){

            cameraMovement.StopCameraMove();
            gameManager.GetComponent<KeyboardInput>().enabled = false;
            gameManager.GetComponent<GameManager>().LoseCondition();

        }

        
    }
}
