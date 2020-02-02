using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpurts : MonoBehaviour {


    [SerializeField]
    public GameObject anvil1, anvil2, anvil3;

    public bool hole1open, hole2open, hole3open;

    private float gameTimer;


    void Start() {
        gameTimer = 0f;
        hole1open = false;
        hole2open = false;
        hole3open = false;
        StartCoroutine(DropAnvil());
    }


    void Update() {
        gameTimer += Time.deltaTime;
    }


    IEnumerator DropAnvil() {

        yield return new WaitForSeconds(1f);

        // avtivate anvil

    }
}
