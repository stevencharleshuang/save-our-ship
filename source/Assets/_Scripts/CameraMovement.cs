using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public bool moveCamera = true;
    private float moveSpeed = 1.5f;

    void Start() {
        
    }


    void Update() {

        if (moveCamera) {
            if (this.transform.position.x >= 62.1f){
                StopCameraMove();
            } else {
                this.transform.position += (transform.right * moveSpeed) * Time.deltaTime;
            }
            
        }
    }

    public void StartCameraMove() {
        moveCamera = true;
    }

    public void StopCameraMove() {
        moveCamera = false;
    }
}
