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

    private int woodCountInt = 0;

    public bool axeOn = false;
    

    AudioManager audioManager;

     private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {   
        AxeOnPlayer.SetActive(false);
        WoodInventory.SetActive(false);
        woodCountText.text = woodCountInt.ToString();
        treeToCut.SetActive(true);
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
    void OnTriggerStay(Collider other) //should this be OnTriggerStay instead? ASK Ariana?!
    {
        if (other.gameObject.tag == "Axe") { 
            
            if ((this.gameObject.tag == "CuttableTree")) {
                
                if (woodCountInt < 4) {

                    //play sound effect 
                    audioManager.PlaySFX(audioManager.chopping);

                    //count up to 4 wood per tree the script is applied to 
                    woodCountInt++;

                    //update count in inventory GUI
                    woodCountText.text = woodCountInt.ToString();

                } else {
                
                //tree disappears
                treeToCut.SetActive(false);

                //wood collected GUI message lower right screen? "All wood collected from this tree"

                //When player has collected enough wood (20), axe on player should disappear entirely 

                //Message should pop up saying enough wood has been collected

                }
            }
        }

    }

}
