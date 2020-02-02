using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvils : MonoBehaviour {

    public GameObject anvil1, anvil2, anvil3;
    public GameObject handToss1, handToss2, handToss3;
    public GameObject sadAnvil1, sadeAnvil2, sadAnvil3;
    public GameObject waterHole1, waterHole2, waterHole3;
    public Vector2 anvil1Pos, anvil2Pos, anvil3Pos;

    private KeyboardInput keyInput;
    public BoatHealth boatHealth;

    public float tempTime;

    void Start() {
        anvil1.SetActive(false);
        anvil2.SetActive(false);
        anvil3.SetActive(false);

        handToss1.SetActive(false);
        handToss2.SetActive(false);
        handToss3.SetActive(false);

        sadAnvil1.SetActive(false);
        sadeAnvil2.SetActive(false);
        sadAnvil3.SetActive(false);

        keyInput = GetComponent<KeyboardInput>();

        anvil1Pos = anvil1.transform.localPosition;
        anvil2Pos = anvil2.transform.localPosition;
        anvil3Pos = anvil3.transform.localPosition;

        StartCoroutine(FirstDrop());
    }


    private void DropEmSon() {
        int num = Random.Range(0,299);
        int dropNumber = num / 100;

        if (dropNumber == 0){

            anvil1.SetActive(true);

        } else if (dropNumber == 1) {
            anvil2.SetActive(true);

        } else {
            anvil3.SetActive(true);

        }

    }

    public void TossAnvil(int anvilNumber) {


        if (anvilNumber == 1) {
            anvil1.SetActive(false);
            waterHole1.GetComponentInParent<WaterHole>().TurnOffWaterHole();
            StartCoroutine(HandTossAnimation(1));
            sadAnvil1.SetActive(true);
            boatHealth.PlayTossSound();
            keyInput.NewKeysForOne();
            keyInput.tool1.enabled = false;

        } else if (anvilNumber == 2) {
            anvil2.SetActive(false);
            waterHole2.GetComponentInParent<WaterHole>().TurnOffWaterHole();
            StartCoroutine(HandTossAnimation(2));
            sadeAnvil2.SetActive(true);
            boatHealth.PlayTossSound();
            keyInput.NewKeysForTwo();
            keyInput.tool2.enabled = false;

        } else {
            anvil3.SetActive(false);
            waterHole3.GetComponentInParent<WaterHole>().TurnOffWaterHole();
            StartCoroutine(HandTossAnimation(3));
            boatHealth.PlayTossSound();
            sadAnvil3.SetActive(true);
            keyInput.NewKeysForThree();
            keyInput.tool3.enabled = false;
        }
    }

    IEnumerator FirstDrop() {

        float firstTime = Random.Range(0.4f, 3.2f);

        int num = Random.Range(0, 299);
        int dropNumber = num / 100;

        yield return new WaitForSeconds(firstTime);

        if (dropNumber == 0){
            anvil1.SetActive(true);
        } else if (dropNumber == 1) {
            anvil2.SetActive(true);
        } else {
            anvil3.SetActive(true);
        }

        InvokeRepeating("DropEmSon", 5f, 5f);
    }


    IEnumerator HandTossAnimation(int numb) {

        if (numb == 1) {
            handToss1.SetActive(true);
            
        } else if (numb == 2) {
            handToss2.SetActive(true);
        } else {
            handToss3.SetActive(true);
        }

        yield return new WaitForSeconds(0.6f);

        if (numb == 1) {
            handToss1.SetActive(false);
            anvil1.transform.localPosition = anvil1Pos;
            sadAnvil1.SetActive(false);
        } else if (numb == 2) {
            handToss2.SetActive(false);
            anvil2.transform.localPosition = anvil2Pos;
            sadeAnvil2.SetActive(false);
        } else {
            handToss3.SetActive(false);
            anvil3.transform.localPosition = anvil3Pos;
        }

    }
}
