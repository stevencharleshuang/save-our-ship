using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInput : MonoBehaviour {

    public KeyCode[] keyInputs;
    [HideInInspector]
    public KeyCode input1A, input1B, input2A, input2B, input3A, input3B;

    public TextMeshPro textOne, textTwo, textThree;
    public BoatHealth boatHealth;

    public SpriteRenderer tool1, tool2, tool3;

    private Anvils anvils;
    private int anvilOnePress, anvilTwoPress, anvilThreePress;

    public BoatMovement boatMovement;

    private void Awake() {
        ShuffleKeyCodeArray();
        anvilOnePress = 0;
        anvilTwoPress = 0;
        anvilThreePress = 0;
        tool1.enabled = false;
        tool2.enabled = false;
        tool3.enabled = false;
    }

    private void Start() {

        anvils = GetComponent<Anvils>();
        GenerateKeyCombination();
        DisplayText();
    }

    void GenerateKeyCombination() {
        input1A = keyInputs[0];
        input1B = keyInputs[1];
        input2A = keyInputs[2];
        input2B = keyInputs[3];
        input3A = keyInputs[4];
        input3B = keyInputs[5];

        int index = System.Array.IndexOf(keyInputs, input1A);

    }


    void ShuffleKeyCodeArray() {
        KeyCode tempKeyCode;
        for (int i = 0; i < keyInputs.Length; i++) {
            int random = Random.Range(0, keyInputs.Length);
            tempKeyCode = keyInputs[random];
            keyInputs[random] = keyInputs[i];
            keyInputs[i] = tempKeyCode;
        }
    }

    void DisplayText() {
        textOne.text = (input1A.ToString() + input1B.ToString());
        textTwo.text = (input2A.ToString() + input2B.ToString());
        textThree.text = (input3A.ToString() + input3B.ToString());
    }

    void Update(){

        if (boatHealth.anvil1IsOnBoat) {


            if ((Input.GetKeyDown(input1A) && Input.GetKey(input1B)) || (Input.GetKeyDown(input1B) && Input.GetKey(input1A))) {
                //boatMovement.RaiseBoat();
                tool1.enabled = true;
                anvilOnePress++;
                if (anvilOnePress == boatHealth.randomPressAmountOne) {
                    boatHealth.anvil1IsOnBoat = false;
                    anvils.TossAnvil(1);
                    boatMovement.LoseAnvil();
                }
            } else {



                tool1.enabled = false;
            }
        }

        if (boatHealth.anvil2IsOnBoat) {

            if ((Input.GetKeyDown(input2A) && Input.GetKey(input2B)) || (Input.GetKeyDown(input2B) && Input.GetKey(input2A))) {
                //boatMovement.RaiseBoat();
                tool2.enabled = true;
                anvilTwoPress++;
                if (anvilTwoPress == boatHealth.randomPressAmountTwo) {
                    boatHealth.anvil2IsOnBoat = false;
                    anvils.TossAnvil(2);
                    boatMovement.LoseAnvil();
                }
            } else {
                tool2.enabled = false;
            }
        }


        if (boatHealth.anvil3IsOnBoat) {

            if ((Input.GetKeyDown(input3A) && Input.GetKey(input3B)) || (Input.GetKeyDown(input3B) && Input.GetKey(input3A))) {
                //boatMovement.RaiseBoat();
                tool3.enabled = true;
                anvilThreePress++;
                if (anvilThreePress == boatHealth.randomPressAmountThree) {
                    boatHealth.anvil3IsOnBoat = false;
                    anvils.TossAnvil(3);
                    boatMovement.LoseAnvil();
                }
            } else {
                tool3.enabled = false;
            }
        }
    }

    public void NewKeysForOne() {

        anvilOnePress = 0;
        textOne.enabled = false;

        int current1Aindex = System.Array.IndexOf(keyInputs, input1A);
        int new1Aindex = current1Aindex + 6;
        //print("1A from " + current1Aindex + " to " + new1Aindex);
        if (new1Aindex >= 26) {
            new1Aindex = 1;
            //print("index A reset");
        }

        input1A = keyInputs[new1Aindex];
        input1B = keyInputs[new1Aindex + 1];

        textOne.text = (input1A.ToString() + input1B.ToString());

        //print("1A = " + input1A.ToString() + " 1B = " + input1B.ToString());

    }

    public void NewKeysForTwo() {
        anvilTwoPress = 0;
        textTwo.enabled = false;
        
        int current2Aindex = System.Array.IndexOf(keyInputs, input2A);
        int new2Aindex = current2Aindex + 6;
        //print("2A from " + current2Aindex + " to " + new2Aindex);

        if (new2Aindex >= 26) {
            new2Aindex = 3;
            //print("index B reset");
        }

        input2A = keyInputs[new2Aindex];
        input2B = keyInputs[new2Aindex + 1];
        textTwo.text = (input2A.ToString() + input2B.ToString());

        //print("2A = " + input2A.ToString() + " 2B = " + input2B.ToString());
    }

    public void NewKeysForThree() {
        anvilThreePress = 0;
        textThree.enabled = false;

        int current3Aindex = System.Array.IndexOf(keyInputs, input3A);
        int new3Aindex = current3Aindex + 6;
        //print("3A from " + current3Aindex + " to " + new3Aindex);
        if (new3Aindex >= 26) {
            new3Aindex = 5;
            //print("index 3 reset");
        }

        input3A = keyInputs[new3Aindex];
        input3B = keyInputs[new3Aindex+1];
        textThree.text = (input3A.ToString() + input3B.ToString());

        //print("3A = " + input3A.ToString() + " 3B = " + input3B.ToString());
    }

    //IEnumerator ToolOn(Sprite tool) {

        

    //    yield return new WaitForSeconds(0.25f);

    //}

}
