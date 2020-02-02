using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHealth : MonoBehaviour {

    private BoatMovement boatMovement;

    public SpriteRenderer boatFace;

    public Sprite happyFace, sadFace, deathFace;

    public AudioSource tossSound;

    public bool anvil1IsOnBoat, anvil2IsOnBoat, anvil3IsOnBoat, alive;
    public int randomPressAmountOne, randomPressAmountTwo, randomPressAmountThree;

    void Start() {
        boatMovement = GetComponent<BoatMovement>();
        anvil1IsOnBoat = false;
        anvil2IsOnBoat = false;
        anvil3IsOnBoat = false;
        alive = true;
        boatFace.sprite = happyFace;
    }


    void Update() {
        if (anvil1IsOnBoat || anvil2IsOnBoat || anvil3IsOnBoat) {
            boatMovement.boatSinking = true;
        } else {
             boatMovement.boatSinking = false;
        }

        if (alive) {
            if (this.transform.position.y <= 0) {
                boatFace.sprite = sadFace;
            } else {
                boatFace.sprite = happyFace;
            }
        }
        
    }

    public void GeneratePressAmount(int holeId) {
        if (holeId == 1) {
            randomPressAmountOne = Random.Range(15, 28);
            //randomPressAmountOne = 2;
        } else if (holeId == 2) {
            randomPressAmountTwo = Random.Range(15, 28);
            //randomPressAmountTwo = 2;
        } else {
            randomPressAmountThree = Random.Range(15, 28);
            //randomPressAmountThree = 2;
        }
    }

    public void BoatHappyFace() {
        boatFace.sprite = happyFace;
    }

    public void BoatSadFace() {
        boatFace.sprite = sadFace;
    }

    public void BoadDeathFace() {
        boatFace.sprite = deathFace;
    }

    public void PlayTossSound() {
        StartCoroutine(TossSound());
    }

    IEnumerator TossSound() {
        yield return new WaitForSeconds(.5f);
        tossSound.Play();
    }
}
