using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeTreeCollision : MonoBehaviour
{
    public GameObject AxeOnPlayer; //asset on player

    public GameObject AxeIcon; //on GUI canvas

    public GameObject WoodInventory; //GUI canvas

    public GameObject treeToCut;

    public Text woodCountText; 

    private bool axeOn;

    private int woodChoppedPerTree = 0;


    AudioManager audioManager;

     private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {   
        AxeOnPlayer.SetActive(false);
        WoodInventory.SetActive(false);
        treeToCut.SetActive(true);
        axeOn = false;
    }

    void Update() {

        //Chopping (when the axe is unlocked)
        if (AxeIcon.activeInHierarchy) {
            
            if (Input.GetKeyDown(KeyCode.X)) {

                if (axeOn == false) {
                    AxeOnPlayer.SetActive(true);
                    WoodInventory.SetActive(true);
                    axeOn = true;
                } else {
                    AxeOnPlayer.SetActive(false);
                    axeOn = false;
                }     
            } 
        }
    }

    //Runs every time axe collides with rigidbody of tree
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Axe") { 
            
            if ((this.gameObject.tag == "CuttableTree" && axeOn == true)) {
                
                while (woodChoppedPerTree < 4) {

                    //play sound effect 
                    audioManager.PlaySFX(audioManager.chopping);

                    //count up to 4 wood per tree the script is applied to 
                    woodChoppedPerTree++;

                    //update count in inventory GUI
                    WoodCountManager.totalChopped += 1;

                } 
                
                //tree disappears
                treeToCut.SetActive(false);

            }

        }

    }

}