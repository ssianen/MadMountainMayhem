using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgePlayerCollision : MonoBehaviour
{
    public GameObject brokenBridge;
    public GameObject fixedBridge;
    public GameObject fixMeSign; 
    public GameObject woodInventory;
    public Text woodCountText; 

    public GameObject axeIcon;

    public GameObject axeOnPlayer;

     void Start() {
        fixMeSign.SetActive(true); 
        brokenBridge.SetActive(true);
        fixedBridge.SetActive(false);
    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            
            if ((this.gameObject.tag == "Bridge" && string.Equals(woodCountText.text, "20"))){

                fixMeSign.SetActive(false); //broken sign disappears
                brokenBridge.SetActive(false); //broken bridge in scene disappears

                fixedBridge.SetActive(true); // fixed bridge in scene appears
                woodInventory.SetActive(false); //wood inventory disappears
                axeIcon.SetActive(false); //axe icon disappears
                axeOnPlayer.SetActive(false); //axe on player disappears
            }

        }
    }
    
}
