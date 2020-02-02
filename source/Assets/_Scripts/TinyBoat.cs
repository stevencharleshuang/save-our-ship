using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyBoat : MonoBehaviour {
    public float tinyBoatMoveSpeed;


    void Update() {
        if (this.transform.position.x >= -55) {
            this.transform.position += (transform.right * tinyBoatMoveSpeed) * Time.deltaTime;
        }
        
    }
}
