using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterHole : MonoBehaviour {

    public GameObject waterHole;
    public int holeNumber;

    public TextMeshPro holeText;

    private BoatHealth boatHealth;
    private AudioSource anvilLandSound;

    void Start() {
        boatHealth = GetComponentInParent<BoatHealth>();
        anvilLandSound = GetComponent<AudioSource>();
        waterHole.SetActive(false);
        holeText.enabled = false;
    }


    void Update() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        waterHole.SetActive(true);
        holeText.enabled = true;
        BoatMovement boatMovement = GetComponentInParent<BoatMovement>();
        boatMovement.DropBoat();

        anvilLandSound.Play();

        if (holeNumber == 1) {
            boatHealth.anvil1IsOnBoat = true;
            boatHealth.GeneratePressAmount(holeNumber);
        } else if (holeNumber == 2) {
            boatHealth.anvil2IsOnBoat = true;
            boatHealth.GeneratePressAmount(holeNumber);
        } else {
            boatHealth.anvil3IsOnBoat = true;
            boatHealth.GeneratePressAmount(holeNumber);
        }
    }

    public void TurnOffWaterHole() {

        waterHole.SetActive(false);

    }

}
